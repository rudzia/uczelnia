using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Threading;

namespace xml_reader
{
    public partial class Form1 : Form
    {
        Thread th;
        private
            XmlSerializer xmlserializer; //Object used for serialization and deserialization
            pola_skierowania skierowanie;//Object containing data from XML "skierowanie.xml"
            static bool XMLValid; //XML validity flag

        public Form1()
        {
            
            skierowanie = new pola_skierowania();
            skierowanie.osoba = new dane_pacjenta();
            skierowanie.tablica_badan = new BadaniaBadanie_konsultacja[20];
            skierowanie.tablica_szkodliwosci = new SzkodliweCzynnik[20];
            skierowanie.data = new DateTime();
            xmlserializer = new XmlSerializer(typeof(pola_skierowania));
            InitializeComponent();
        }
        private XmlReader CreateXmlReaderWithSchemaValidation(StreamReader stream)
        {
            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.ValidationType = ValidationType.Schema;
            readerSettings.Schemas.Add(null, @"skierowanie.xsd");
            return XmlReader.Create(stream, readerSettings);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
                XmlReader xmlReader = CreateXmlReaderWithSchemaValidation(streamReader);


                try
                {
                    xmlserializer = new XmlSerializer(typeof(pola_skierowania));
                    skierowanie = (pola_skierowania)xmlserializer.Deserialize(xmlReader);
                    FillFormFields();
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "Niepoprawny format dokumentu XML",
                        "Błąd",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
                finally
                {
                    streamReader.Close();
                    xmlReader.Close();
                }
            }
        }
        private void FillFormFields()
        {
            //Passing data to GUI
            textBox1.Text = skierowanie.nazwa_zakladu_pracy;
            textBox2.Text = skierowanie.osoba.imie;
            textBox3.Text = skierowanie.osoba.nazwisko;
            textBox4.Text = skierowanie.osoba.czas_zatrudnienia;
            textBox5.Text = skierowanie.osoba.ulica;
            textBox6.Text = skierowanie.osoba.regon;
            textBox7.Text = skierowanie.osoba.pesel;
            textBox8.Text = skierowanie.osoba.stanowisko;
            textBox9.Text = skierowanie.osoba.obecne_stanowisko;
            textBox11.Text = skierowanie.dodatkowe_uwagi_A;
            textBox12.Text = skierowanie.dodatkowe_uwagi_B;
            textBox13.Text = skierowanie.lekarz;
            textBox14.Text = skierowanie.zlecajacy;
            textBox15.Text = skierowanie.osoba.miasto;
            string rodz_badania = skierowanie.osoba.rodzaj_badania.ToString();
            if (rodz_badania == "zmianastanowiskapracy")
                comboBox1.Text = "zmiana stanowiska pracy";
            else
                comboBox1.Text = skierowanie.osoba.rodzaj_badania.ToString();
            dateTimePicker1.Value = skierowanie.data;
            maskedTextBox1.Text = skierowanie.osoba.kod_pocztowy;

            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(skierowanie.tablica_szkodliwosci.Length);
            for (int i = 0; i < skierowanie.tablica_szkodliwosci.Length; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = skierowanie.tablica_szkodliwosci[i].rodzaj_czynnika;
                dataGridView1.Rows[i].Cells[1].Value = skierowanie.tablica_szkodliwosci[i].wyniki_pomiarow;
                dataGridView1.Rows[i].Cells[2].Value = skierowanie.tablica_szkodliwosci[i].NDS_NDN;
                dataGridView1.Rows[i].Cells[3].Value = skierowanie.tablica_szkodliwosci[i].uwagi;
            };

            dataGridView2.Rows.Clear();
            dataGridView2.Rows.Add(skierowanie.tablica_badan.Length);
            for (int i = 0; i < skierowanie.tablica_badan.Length; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = skierowanie.tablica_badan[i].badanie;
                dataGridView2.Rows[i].Cells[1].Value = skierowanie.tablica_badan[i].czestotliwosc;
                dataGridView2.Rows[i].Cells[2].Value = skierowanie.tablica_badan[i].uwagi;
            };
            toolStripStatusLabel1.Text = "Status: ";
            toolStripStatusLabel2.Text = "Wypełniono formularz danymi z pliku .xml";

        }
        private void checkAllFields()
        {
            string message = "Niewypełnione pola:\n";
            if (textBox1.Text == "")
                message += "* Nazwa zakładu pracy\n";
            if (textBox2.Text == "")
                message += "* Imię\n";
            if (textBox3.Text == "")
                message += "* Nazwisko\n";
            if (textBox7.Text == "")
                message += "* PESEL\n";
            if (textBox4.Text == "")
                message += "* Czas zatrudnienia\n";
            if (textBox5.Text == "")
                message += "* Ulica\n";
            if (maskedTextBox1.Text == "")
                message += "* Kod pocztowy\n";
            if (textBox15.Text == "")
                message += "* Miasto\n";
            if (comboBox1.Text == "")
                message += "* Rodzaj badania\n";
            if (textBox6.Text == "")
                message += "* REGON\n";
            if (textBox8.Text == "")
                message += "* Zatrudniony na stanowisko \n";
            if (textBox14.Text == "")
                message += "* Osoba zlecająca\n";
            if (dataGridView1.Rows[0].Cells[0].Value == null)
                message += "* Tablica szkodliwości\n";
            if (dataGridView2.Rows[0].Cells[0].Value == null)
                message += "* Tablica badań\n";
            if (textBox13.Text == "")
                message += "* Imię i nazwisko Lekarza\n";

            if (message != "Niewypełnione pola:\n")
            {
                toolStripStatusLabel1.Text = "Status: ";
                toolStripStatusLabel2.Text = "Wykryto puste pola!";
                MessageBox.Show(
                       message + "\nPlik xml zostanie zapisany z pustymi polami!",
                       "Błąd",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning
                       );
            }
            else {
                toolStripStatusLabel1.Text = "Status: ";
                toolStripStatusLabel2.Text = "Wszystkie wymagane pola są uzupełnione.";
            }
            
        }
        private void updateTablcaSzkodliwosci() //metoda do obslugi tabeli
        {
            skierowanie.tablica_szkodliwosci = new SzkodliweCzynnik[dataGridView1.RowCount - 1];
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
                skierowanie.tablica_szkodliwosci[i] = new SzkodliweCzynnik();
                skierowanie.tablica_szkodliwosci[i].rodzaj_czynnika = dataGridView1.Rows[i].Cells[1].Value.ToString();
                skierowanie.tablica_szkodliwosci[i].wyniki_pomiarow = dataGridView1.Rows[i].Cells[2].Value.ToString();
                skierowanie.tablica_szkodliwosci[i].NDS_NDN = dataGridView1.Rows[i].Cells[3].Value.ToString();
                skierowanie.tablica_szkodliwosci[i].uwagi = dataGridView1.Rows[i].Cells[4].Value.ToString();
            }
        }

        //C# function for using Apache FOP to generate PDF from XML
        //Author: Jaroslaw Magiera, Gdansk Universtiy of Technology
        private void exportToPdfButton_Click(object sender, EventArgs e)
        {
            //Create a batch file
            String fopDir = "D:\\IBM\\semestr 3\\dokumenty cyfrowe\\zadanie 3\\fop-1.1\\fop-1.1"; //Apache FOP working directory
	        String xmlDir = ".\\"; //Directory where XML resides (Our apllication working directory)
            String xslDir = ".\\"; //Directory where XSL resides (Our apllication working directory)
            String pdfDir = ".\\"; //Directory where PDFs will be saved (Our apllication working directory)
            String fopXconfFile = "fop.xconf"; //FOP configuration file (necessary to import Windows system fonts)
            String xmlFile = "zamowienie_mod.xml"; //Input XML file name
            String xslFile = "zamowienie_fo.xsl"; //Input XSL file name
            String pdfFile = "zamowienie_mod.pdf"; //Output PDF file name
            FileStream fs = new FileStream("pdfexport.bat", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //Writing Windows commands in separate lines of our batch (*.bat) file
            sw.WriteLine("call {0}fop -c {1}{2} -xml {3}{4} -xsl {5}{6} -pdf {7}{8}", fopDir, fopDir, fopXconfFile, xmlDir, xmlFile, xslDir, xslFile, pdfDir, pdfFile, fopDir);
            sw.WriteLine("pause"); //the above "call" is needed to execute the "pause" command after FOP exits
            sw.Close();
            fs.Close();

            // Start the pdf export process
            //using System.Diagnostics
            Process p = new Process();
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.FileName = "pdfexport.bat"; //Batch file created in application working directory
            p.Start();
            p.WaitForExit(); //Wait for PDF generation before opening it


            // Start process opening generated PDF
            p = new Process();
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.RedirectStandardOutput = false;
            try
            {
                p.StartInfo.FileName = pdfDir + pdfFile;
                p.Start();
                //p.WaitForExit(); //If this line was left uncommented, our application would be inactive until PDF browser was closed

            }
            catch (Exception exc) { } //Here you can catch exception if PDF cannot be opened for some reason
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBox1.GetItemText(comboBox1.SelectedItem);
            if (selected == "zmiana stanowiska pracy")
                selected = "zmianastanowiskapracy";
            skierowanie.osoba.rodzaj_badania = (Badanie_type)Enum.Parse(typeof(Badanie_type), selected);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            skierowanie.osoba.imie = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            skierowanie.osoba.nazwisko = textBox3.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            skierowanie.nazwa_zakladu_pracy = textBox1.Text;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
           //updateTablcaSzkodliwosci();
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
           //updateTablcaSzkodliwosci(); tu musi byc inna obsluga tablicy
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private XmlDocument getValidXmlDocumentFromModel()
        {

            MemoryStream ms = new MemoryStream();
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(pola_skierowania));
                XmlWriterSettings writerSettings = new XmlWriterSettings();
                writerSettings.Indent = true;
                writerSettings.IndentChars = ("\t");
                ms.Position = 0;
                XmlWriter writer = XmlWriter.Create(ms, writerSettings);
                xmlSerializer.Serialize(writer, skierowanie);

                ms.Position = 0;
                StreamReader streamReader = new StreamReader(ms);
                XmlReader reader = CreateXmlReaderWithSchemaValidation(streamReader);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(reader);


                return xmlDoc;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ms.Close();
            }
        }

        private void button_validatesave_Click(object sender, EventArgs e)
        {
            checkAllFields();
            isValid(sender, e);
            
            try
            {
                XmlDocument xmlDoc = getValidXmlDocumentFromModel();
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    xmlDoc.Save(saveFileDialog1.FileName);
                }
            }
            catch (XmlSchemaValidationException)
            {
                MessageBox.Show(
                        "Niepoprawnie wypełnione pola w dokumencie."+ 
                        "\nPlik nie zostanie zapisany. Proszę o korektę.",
                        "Błąd",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
            }
        }

        private void isValid(object sender, EventArgs e)
        {

                MemoryStream ms = new MemoryStream(); //creating a stream for storing XML file with modified data
                XmlWriter writer = XmlWriter.Create(ms); //creating writer for writing XML file to stream
                xmlserializer.Serialize(writer, skierowanie);

                XmlReaderSettings xrset = new XmlReaderSettings(); //definition of XML reader settings
                xrset.ValidationType = ValidationType.Schema; //validation based on XML Schema
                ms.Position = 0; //setting the pointer on beginning of memory stream
                XmlReader reader = XmlReader.Create(ms, xrset); //creating a reader for reading XML from memory stream

                XmlDocument xdoc = new XmlDocument(); //creating an XML document
                xdoc.Load(reader); //loading document from memory stream
                xdoc.Schemas.Add(null, @"skierowanie.xsd"); //connecting the XML document with schema from "zamowienie.xsd"
                //ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventCallback); //setting the event handler for handling incorrect validation events
                XMLValid = true; //setting the default value of XML validity flag for true
                xdoc.Validate(ValidationEventHandler); //performing validation

        }
        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            XmlSeverityType type = XmlSeverityType.Warning;
            if (Enum.TryParse<XmlSeverityType>("Error", out type))
            {
                if (type == XmlSeverityType.Error)
                {
                    XMLValid = false;
                    string a = e.Message.Split('.')[0];
                    string[] b = a.Split(' ');

                    if (b.Contains("'imie'") && b.Contains("Pattern"))
                    {
                        MessageBox.Show(
                        "Pole 'Imię' jest niepoprawne.\nProszę poprawnie uzupełnić pole.",
                        "Walidacja",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    }
                    else if (b.Contains("'nazwisko'") && b.Contains("Pattern")) { 
                        MessageBox.Show(
                        "Pole 'Nazwisko' jest niepoprawne. \nProszę poprawnie uzupełnić pole.",
                        "Walidacja",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    }
                    else if (b.Contains("'pesel'") && b.Contains("Pattern"))
                    {
                        MessageBox.Show(
                        "Pole 'PESEL' jest niepoprawne. Wymagane 11 cyfr.",
                        "Walidacja",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    }
                    else if (b.Contains("'kod_pocztowy'") && b.Contains("Pattern"))
                    {
                        MessageBox.Show(
                        "Pole 'Kod_pocztowy' jest niepoprawne. Struktura XX-XXX.",
                        "Walidacja",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    }
                    else if (b.Contains("'regon'") && b.Contains("Pattern"))
                    {
                        MessageBox.Show(
                        "Pole 'REGON' jest niepoprawne. Wymagane 9 lub 14 cyfr.",
                        "Walidacja",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    }
                    else if (b.Contains("'miasto'") && b.Contains("Pattern"))
                    {
                        //MIASTA NIE DA SIE  ZWALIDOWAC
                        MessageBox.Show(
                        "Pole 'Miasto' jest niepoprawne. \nProszę poprawnie uzupełnić pole.",
                        "Walidacja",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    }
                    else if (b.Contains("'rodzaj_badania'") && b.Contains("Pattern"))
                    {
                        
                        MessageBox.Show(
                        "Pole 'Typ_badania' jest niepoprawne. \nProszę poprawnie uzupełnić pole.",
                        "Walidacja",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    }

                }
            }
        }
        
        //Callback function for serving the events of incorrect validation
        static void ValidationEventCallback(object sender, ValidationEventArgs e)
        {

            string msg;
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    //MessageBox.Show(e.Message, "Validation Error", MessageBoxButtons.OK);
                    msg = "Walidacja nie przebiegła pomyślnie: Błąd\n" + e.Message;
                    MessageBox.Show(msg, "Walidacja: Błąd", MessageBoxButtons.OK);
                    XMLValid = false;
                    break;
                case XmlSeverityType.Warning:
                    //MessageBox.Show(e.Message, "Validation Warning", MessageBoxButtons.OK);
                    msg = "Walidacja nie przebiegła pomyślnie: Ostrzeżenie\n" + e.Message;
                    MessageBox.Show(msg, "Walidacja: Ostrzeżenie", MessageBoxButtons.OK);
                    XMLValid = false;
                    break;
            }

        }
        
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            skierowanie.data = dateTimePicker1.Value;
        }

        private void updateTablicaBadan() //metoda do obslugi tabeli
        {
            skierowanie.tablica_badan = new BadaniaBadanie_konsultacja[dataGridView2.RowCount - 1];

            try
            {
                for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                {
                    dataGridView2.Rows[i].Cells[0].Value = i + 1;
                    skierowanie.tablica_badan[i] = new BadaniaBadanie_konsultacja();
                    skierowanie.tablica_badan[i].badanie = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    skierowanie.tablica_badan[i].czestotliwosc = dataGridView2.Rows[i].Cells[2].Value.ToString();
                    skierowanie.tablica_badan[i].uwagi = dataGridView2.Rows[i].Cells[3].Value.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                            "Wszystkie pola w tabeli muszą zostać uzupełnione.\n",
                            "Błąd",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );
            }
        }

        private void dataGridView2_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            //updateTablicaBadan();
            isValid(sender, e);
        }

        private void dataGridView2_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            //updateTablicaBadan();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            skierowanie.osoba.pesel = textBox7.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            skierowanie.osoba.ulica = textBox5.Text;
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            skierowanie.osoba.miasto = textBox15.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            skierowanie.osoba.regon = textBox6.Text;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            skierowanie.osoba.obecne_stanowisko = textBox9.Text;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            skierowanie.osoba.stanowisko = textBox8.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            skierowanie.osoba.czas_zatrudnienia = textBox4.Text;
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            skierowanie.zlecajacy = textBox14.Text;
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            isValid(sender, e);

        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            //nazwisko
            isValid(sender, e);
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            //pesel
            isValid(sender, e);
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            //ulica
            //isValid(sender, e);
            
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            //nazwa zakladu rpracy
            isValid(sender, e);
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            //regon
            isValid(sender, e);
        }

        private void textBox9_Validating(object sender, CancelEventArgs e)
        {
            isValid(sender, e);
        }

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {
            //stanowisko
            isValid(sender, e);
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            isValid(sender, e);
        }

        private void textBox14_Validating(object sender, CancelEventArgs e)
        {
            isValid(sender, e);
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            
            skierowanie.lekarz = textBox13.Text;
        }

        private void textBox13_Validating(object sender, CancelEventArgs e)
        {
            isValid(sender, e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox15_Validating(object sender, CancelEventArgs e)
        {
            //miasto
            isValid(sender, e);
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            //nie waliduje sie
            isValid(sender, e);
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            skierowanie.osoba.kod_pocztowy= maskedTextBox1.Text;
        }

        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        {
            isValid(sender, e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //exportToPdfButton_Click(sender, e);
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("test.pdf", FileMode.Create));
            doc.Open();//open doc to write
            Paragraph new_line = new Paragraph("\n");
            //set fonts
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, true);
            var fontBig = new iTextSharp.text.Font(bf, 15);
            var fontSmall = new iTextSharp.text.Font(bf, 11);

            Paragraph p = new Paragraph("Skierowanie na badania profilaktyczne",fontBig);
            p.Alignment = Element.ALIGN_CENTER;
            doc.Add(p);
            doc.Add(new_line);

            PdfPTable A = new PdfPTable(1);
            A.AddCell("A.");
            //A.TotalWidth = 10f;
            A.HorizontalAlignment = Element.ALIGN_LEFT;
            A.WidthPercentage = 5;
            doc.Add(A);
            doc.Add(new_line);

            PdfPTable tablica_szkodliwosci = new PdfPTable(dataGridView1.Columns.Count);
            //add headers
            for (int i = 0; i < dataGridView1.Columns.Count; ++i)
            {
                PdfPCell cell = new PdfPCell(new Phrase(dataGridView1.Columns[i].HeaderText, fontSmall));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                tablica_szkodliwosci.AddCell(cell);
            }

            //flag the first row as a header
            tablica_szkodliwosci.HeaderRows = 1;

            //add the actual rows to the table
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; ++j)
                {
                    if (dataGridView1[j, i].Value != null)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(dataGridView1[j, i].Value.ToString(), fontSmall));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        tablica_szkodliwosci.AddCell(cell);
                    }
                }
            }
            doc.Add(tablica_szkodliwosci);

            Paragraph uwagiA;
            if (skierowanie.dodatkowe_uwagi_B == null)
                uwagiA = new Paragraph("Dodatkowe uwagi: ", fontSmall);
            else
                uwagiA = new Paragraph("Dodatkowe uwagi: " + skierowanie.dodatkowe_uwagi_A.ToString(), fontSmall);
            uwagiA.Alignment = Element.ALIGN_LEFT;
            doc.Add(uwagiA);
            doc.Add(new_line);
            
            PdfPTable B = new PdfPTable(1);
            B.AddCell("B.");
            //A.TotalWidth = 10f;
            B.HorizontalAlignment = Element.ALIGN_LEFT;
            B.WidthPercentage = 5;
            doc.Add(B);
            doc.Add(new_line);

            PdfPTable tablica_badan = new PdfPTable(dataGridView2.Columns.Count);
            //add headers
            for (int i = 0; i < dataGridView2.Columns.Count; ++i)
            {
                PdfPCell cell = new PdfPCell(new Phrase(dataGridView2.Columns[i].HeaderText, fontSmall));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                tablica_badan.AddCell(cell);
            }

            //flag the first row as a header
            tablica_badan.HeaderRows = 1;

            //add the actual rows to the table
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                for (int j = 0; j < dataGridView2.Columns.Count; ++j)
                {
                    if (dataGridView2[j, i].Value != null)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(dataGridView2[j, i].Value.ToString(), fontSmall));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        tablica_badan.AddCell(cell);
                    }
                }
            }
            doc.Add(tablica_badan);

            Paragraph uwagiB;
            if (skierowanie.dodatkowe_uwagi_B == null)
                uwagiB = new Paragraph("Dodatkowe uwagi: ", fontSmall);
            else
                uwagiB = new Paragraph("Dodatkowe uwagi: " + skierowanie.dodatkowe_uwagi_B.ToString(), fontSmall);
            
            uwagiB.Alignment = Element.ALIGN_LEFT;
            doc.Add(uwagiB);
            doc.Add(new_line);

            doc.Close();
        }

        private void button_NowyPlik_Click(object sender, EventArgs e)
        {
            //this.Hide();//how to close it?
            //Form1 newFile = new Form1();
            //newFile.Show();
            this.Close();
            th = new Thread(openNewForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openNewForm(object o)
        {
            Application.Run(new Form1());
        }
    }


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("skierowanie", Namespace = "", IsNullable = false)]
    public partial class pola_skierowania
    {

        private dane_pacjenta osobaField;

        private SzkodliweCzynnik[] tablica_szkodliwosciField;

        private string dodatkowe_uwagi_AField;

        private System.DateTime dataField;

        private string zlecajacyField;

        private BadaniaBadanie_konsultacja[] tablica_badanField;

        private string dodatkowe_uwagi_BField;

        private string lekarzField;

        private string nazwa_zakladu_pracyField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public dane_pacjenta osoba
        {
            get
            {
                return this.osobaField;
            }
            set
            {
                this.osobaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("czynnik", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public SzkodliweCzynnik[] tablica_szkodliwosci
        {
            get
            {
                return this.tablica_szkodliwosciField;
            }
            set
            {
                this.tablica_szkodliwosciField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string dodatkowe_uwagi_A
        {
            get
            {
                return this.dodatkowe_uwagi_AField;
            }
            set
            {
                this.dodatkowe_uwagi_AField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "date")]
        public System.DateTime data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string zlecajacy
        {
            get
            {
                return this.zlecajacyField;
            }
            set
            {
                this.zlecajacyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("badanie_konsultacja", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public BadaniaBadanie_konsultacja[] tablica_badan
        {
            get
            {
                return this.tablica_badanField;
            }
            set
            {
                this.tablica_badanField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string dodatkowe_uwagi_B
        {
            get
            {
                return this.dodatkowe_uwagi_BField;
            }
            set
            {
                this.dodatkowe_uwagi_BField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string lekarz
        {
            get
            {
                return this.lekarzField;
            }
            set
            {
                this.lekarzField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string nazwa_zakladu_pracy
        {
            get
            {
                return this.nazwa_zakladu_pracyField;
            }
            set
            {
                this.nazwa_zakladu_pracyField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class dane_pacjenta
    {

        private string imieField;

        private string nazwiskoField;

        private string peselField;

        private string ulicaField;

        private string kod_pocztowyField;

        private string miastoField;

        private string czas_zatrudnieniaField;

        private string stanowiskoField;

        private string regonField;

        private string obecne_stanowiskoField;

        private Badanie_type rodzaj_badaniaField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string imie
        {
            get
            {
                return this.imieField;
            }
            set
            {
                this.imieField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string nazwisko
        {
            get
            {
                return this.nazwiskoField;
            }
            set
            {
                this.nazwiskoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "integer")]
        public string pesel
        {
            get
            {
                return this.peselField;
            }
            set
            {
                this.peselField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ulica
        {
            get
            {
                return this.ulicaField;
            }
            set
            {
                this.ulicaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string kod_pocztowy
        {
            get
            {
                return this.kod_pocztowyField;
            }
            set
            {
                this.kod_pocztowyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string miasto
        {
            get
            {
                return this.miastoField;
            }
            set
            {
                this.miastoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string czas_zatrudnienia
        {
            get
            {
                return this.czas_zatrudnieniaField;
            }
            set
            {
                this.czas_zatrudnieniaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string stanowisko
        {
            get
            {
                return this.stanowiskoField;
            }
            set
            {
                this.stanowiskoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "integer")]
        public string regon
        {
            get
            {
                return this.regonField;
            }
            set
            {
                this.regonField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string obecne_stanowisko
        {
            get
            {
                return this.obecne_stanowiskoField;
            }
            set
            {
                this.obecne_stanowiskoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Badanie_type rodzaj_badania
        {
            get
            {
                return this.rodzaj_badaniaField;
            }
            set
            {
                this.rodzaj_badaniaField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    public enum Badanie_type
    {

        /// <remarks/>
        wstępne,

        /// <remarks/>
        okresowe,

        /// <remarks/>
        kontrolne,

        /// <remarks/>
        końcowe,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("zmiana stanowiska pracy")]
        zmianastanowiskapracy,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SzkodliweCzynnik
    {

        private string rodzaj_czynnikaField;

        private string wyniki_pomiarowField;

        private string nDS_NDNField;

        private string uwagiField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string rodzaj_czynnika
        {
            get
            {
                return this.rodzaj_czynnikaField;
            }
            set
            {
                this.rodzaj_czynnikaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string wyniki_pomiarow
        {
            get
            {
                return this.wyniki_pomiarowField;
            }
            set
            {
                this.wyniki_pomiarowField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string NDS_NDN
        {
            get
            {
                return this.nDS_NDNField;
            }
            set
            {
                this.nDS_NDNField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uwagi
        {
            get
            {
                return this.uwagiField;
            }
            set
            {
                this.uwagiField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class BadaniaBadanie_konsultacja
    {

        private string badanieField;

        private string czestotliwoscField;

        private string uwagiField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string badanie
        {
            get
            {
                return this.badanieField;
            }
            set
            {
                this.badanieField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string czestotliwosc
        {
            get
            {
                return this.czestotliwoscField;
            }
            set
            {
                this.czestotliwoscField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uwagi
        {
            get
            {
                return this.uwagiField;
            }
            set
            {
                this.uwagiField = value;
            }
        }
    }
}