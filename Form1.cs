using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Defect_Counter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ////////////////////////////////////////////
 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog.SelectedPath;
                LoadLogs();
            }
        }

        private void LoadLogs()
        {
            // Validar campos de entrada
            if (string.IsNullOrWhiteSpace(txtPath.Text) || string.IsNullOrWhiteSpace(txtExtension.Text) || dtpDate.Value == null)
            {
                MessageBox.Show("Por favor, ingrese la extensión, la fecha y la ruta de la carpeta.", "Información incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Limpiar la lista de logs
            lstLogs.Items.Clear();

            // Verificar si la ruta especificada existe
            if (!Directory.Exists(txtPath.Text))
            {
                MessageBox.Show("La ruta de la carpeta especificada no existe.", "Error de ruta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener todos los archivos con la extensión especificada en la ruta dada
            var files = Directory.GetFiles(txtPath.Text, $"*.{txtExtension.Text}");

            // Convertir la fecha seleccionada en el DateTimePicker a la fecha sin la hora
            var selectedDate = dtpDate.Value.Date;

            // Filtrar los archivos por la fecha de modificación
            var filteredFiles = files.Where(file =>
            {
                var lastWriteTime = File.GetLastWriteTime(file).Date;
                return lastWriteTime == selectedDate;
            }).ToArray();

            // Mostrar los archivos filtrados en el ListBox
            if (filteredFiles.Length == 0)
            {
                MessageBox.Show("No se encontraron archivos con la extensión y fecha especificadas.", "No se encontraron archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (string file in filteredFiles)
                {
                    lstLogs.Items.Add(Path.GetFileName(file));
                }
            }
        }




        //////////////////////////////////////////////


        private void btnProcess_Click(object sender, EventArgs e)
        {
            lstDefects.Items.Clear(); // Limpiar la lista de defectos

            string outputDir = Path.Combine(txtPath.Text, dtpDate.Value.ToString("ddMMyyyy"));
            Directory.CreateDirectory(outputDir);

            string outputFilePath = Path.Combine(outputDir, $"{dtpDate.Value.ToString("ddMMyyyy")}_Defects.txt");

            var allDefects = new HashSet<DefectRecord>(new DefectComparer()); // Usar HashSet para evitar duplicados

            foreach (string logFile in lstLogs.Items)
            {
                string logFilePath = Path.Combine(txtPath.Text, logFile);
                var defectList = ProcessLogFile(logFilePath);
                foreach (var defect in defectList)
                {
                    allDefects.Add(defect); // Agregar defectos al HashSet
                }
            }

            // Mostrar los defectos en el ListBox
            foreach (var defect in allDefects)
            {
                lstDefects.Items.Add($"{defect.SerialNumber}\t{defect.CardNumber}\t{defect.DefectDescription}");
            }

            // Escribir los defectos en el archivo de salida con formato decorado
            using (StreamWriter sw = new StreamWriter(outputFilePath))
            {
                sw.WriteLine("/" + new string('-', 60) + "/");
                sw.WriteLine("/ Serial Number / Card Number / Defect /");
                sw.WriteLine("/" + new string('-', 60) + "/");

                foreach (var defect in allDefects)
                {
                    sw.WriteLine($"/ {defect.SerialNumber.PadRight(20)} / {defect.CardNumber.PadRight(20)} / {defect.DefectDescription.PadRight(20)} /");
                }

                if (!allDefects.Any())
                {
                    sw.WriteLine("/ No defects found /");
                }

                sw.WriteLine("/" + new string('-', 60) + "/");
            }

            MessageBox.Show("Procesamiento completo.");
        }

        private List<DefectRecord> ProcessLogFile(string logFilePath)
        {
            List<DefectRecord> defectRecords = new List<DefectRecord>();
            string serialNumber = string.Empty;
            string cardNumber = string.Empty;

            foreach (string line in File.ReadLines(logFilePath))
            {
                if (line.StartsWith("{@BTEST|"))
                {
                    serialNumber = ExtractSerialNumber(line);
                    cardNumber = ExtractCardNumber(line); // Extrae el número de tarjeta de la línea {@BTEST|
                }
                else if (line.Contains("HAS FAILED"))
                {
                    string defect = ExtractDefect(line);
                    defectRecords.Add(new DefectRecord(serialNumber, cardNumber, defect));
                }
            }

            return defectRecords;
        }

        private string ExtractSerialNumber(string line) => Regex.Match(line, @"{\@BTEST\|([^|]+)").Groups[1].Value;

        private string ExtractCardNumber(string line)
        {
            // Extrae el número de tarjeta entre {@BTEST| y el siguiente | en la línea
            var match = Regex.Match(line, @"{\@BTEST\|(?:[^|]*\|){11}(\d+)");
            return match.Success ? match.Groups[1].Value : string.Empty;
        }

        private string ExtractDefect(string line)
        {
            // Extrae la descripción del defecto entre {@RPT| y HAS FAILED
            var match = Regex.Match(line, @"{\@RPT\|\d+%([^ ]+) HAS FAILED");
            return match.Success ? match.Groups[1].Value : string.Empty;
        }

        public class DefectRecord
        {
            public string SerialNumber { get; set; }
            public string CardNumber { get; set; }
            public string DefectDescription { get; set; }

            public DefectRecord(string serialNumber, string cardNumber, string defectDescription)
            {
                SerialNumber = serialNumber;
                CardNumber = cardNumber;
                DefectDescription = defectDescription;
            }
        }

        // Comparador para evitar duplicados
        public class DefectComparer : IEqualityComparer<DefectRecord>
        {
            public bool Equals(DefectRecord x, DefectRecord y)
            {
                if (x == null || y == null) return false;
                return x.SerialNumber == y.SerialNumber &&
                       x.CardNumber == y.CardNumber &&
                       x.DefectDescription == y.DefectDescription;
            }

            public int GetHashCode(DefectRecord obj)
            {
                if (obj == null) return 0;
                int hashSerialNumber = obj.SerialNumber?.GetHashCode() ?? 0;
                int hashCardNumber = obj.CardNumber?.GetHashCode() ?? 0;
                int hashDefectDescription = obj.DefectDescription?.GetHashCode() ?? 0;
                return hashSerialNumber ^ hashCardNumber ^ hashDefectDescription;
            }
        }

    }
}
