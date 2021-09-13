using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace tehtava18
{
    public partial class henkilot_Form : Form
    {
        DataTable oppilaitos = new DataTable();
        DataTable vastuuHenkilot = new DataTable();
        DataTable yhteys = new DataTable();

        public henkilot_Form()
        {
            InitializeComponent();
        }

        private void henkilot_Form_Load(object sender, EventArgs e)
        {
            taytaOppilaitosTaulukko();
            taytaVastuuHenkiloTaulukko();
            oppilaitos_comboBox.DataSource = oppilaitos;
            oppilaitos_comboBox.DisplayMember = "ONimi";
        }

        private void oppilaitos_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string viite = oppilaitos.Rows[oppilaitos_comboBox.SelectedIndex]["OID"].ToString();
            osoite_label.Text = oppilaitos.Rows[oppilaitos_comboBox.SelectedIndex]["OKatuosoite"].ToString();
            postinuero_label.Text = oppilaitos.Rows[oppilaitos_comboBox.SelectedIndex]["OPostinumero"].ToString();
            postitoimi_label.Text = oppilaitos.Rows[oppilaitos_comboBox.SelectedIndex]["OPostitoimipaikka"].ToString();
            puhelin_label.Text = oppilaitos.Rows[oppilaitos_comboBox.SelectedIndex]["OPuhelin"].ToString();

            yhteys = vastuuHenkilot.Select("OID =" + viite).CopyToDataTable();
            vastuuhenkilo_comboBox.DataSource = yhteys;
            vastuuhenkilo_comboBox.DisplayMember = "VNimi";
        }

        private void vastuuhenkilo_comboBox_TextChanged(object sender, EventArgs e)
        {
            titteli_label.Text = yhteys.Rows[vastuuhenkilo_comboBox.SelectedIndex]["VTitteli"].ToString();
            osasto_label.Text = yhteys.Rows[vastuuhenkilo_comboBox.SelectedIndex]["VSijainti"].ToString();
            sahkopost_label.Text = yhteys.Rows[vastuuhenkilo_comboBox.SelectedIndex]["VSahkoposti"].ToString();
            puhelin_label.Text = yhteys.Rows[vastuuhenkilo_comboBox.SelectedIndex]["VPuhelin"].ToString();
        }

        private void taytaOppilaitosTaulukko()
        {
            oppilaitos.Columns.Add("OID", typeof(int));
            oppilaitos.Columns.Add("ONimi");
            oppilaitos.Columns.Add("OKatuosoite");
            oppilaitos.Columns.Add("OPostinumero");
            oppilaitos.Columns.Add("OPostitoimipaikka");
            oppilaitos.Columns.Add("OPuhelin");
            // Alueet
            oppilaitos.Rows.Add(1, "StadinAO", "Haatulantie 2", "00550", "Helsinki", "09 319 8600");
            oppilaitos.Rows.Add(2, "Omnia", "Armas Launiksen katu 9", "02650", "Espoo", "046 887 1371");
            oppilaitos.Rows.Add(3, "varia", "Rälssitie 13", "01530", "vantaa", "040 182 4668");
            oppilaitos.Rows.Add(4, "Keuda", "Sibeliuksenväylä 55 A", "04400", "Järvenpää", "09 27 381");
        }

        private void taytaVastuuHenkiloTaulukko()
        {
            vastuuHenkilot.Columns.Add("OID", typeof(int));
            vastuuHenkilot.Columns.Add("VNimi");
            vastuuHenkilot.Columns.Add("VTitteli");
            vastuuHenkilot.Columns.Add("VSijainti");
            vastuuHenkilot.Columns.Add("VSahkoposti");
            vastuuHenkilot.Columns.Add("VPuhelin");
            //Henkilöt
            vastuuHenkilot.Rows.Add(1, "Sirpa Lindroos", "Rehtori", "Kampus 1", "sirpa.lindroos@hel.fi", "050 540 4434");
            vastuuHenkilot.Rows.Add(1, "Hanna Laurila", "Rehtori", "Kaupus 2", "hanna.laurila@hel.fi", "040 676 5583");
            vastuuHenkilot.Rows.Add(1, "Annele Ranta", "Rehtori", "Kampus 3", "annele.ranta@hel.fi", "040 631 55667");
            vastuuHenkilot.Rows.Add(1, "Eeva Sahlman", "Rehtori", "Kampus 4", "eeva.sahlam@hel.fi", "040 336 1017");
            vastuuHenkilot.Rows.Add(1, "Marko Aaltonen", "Rehtori", "Kampus 5", "eeva.sahlman@hel.fi", "040 336 1017");
            vastuuHenkilot.Rows.Add(2, "Tuula Antola", "Koulutuskuntayhtymän johtaja", "Yleishalinto", "tuula.antola 2omnia.fi", "");
            vastuuHenkilot.Rows.Add(2, "Tapio Siukonen", "Hallintojohtaja", "Yleishallinto", "tapio.siukonen@omia.fi", "044 369 6600");
            vastuuHenkilot.Rows.Add(2, "Tuukko Soini", "Kehittämisjohtaja", "Yleishallinto", "tuukka.soini@omnia.fi", "046 877 2952");
            vastuuHenkilot.Rows.Add(2, "Riika-Maria Yli-Suomu", "Liiketoimintajohtaja", "Elinvoima- ja työllisyyspalvelut", "riikka-maria.yli-suomu@omnia.fi", "050 348 6544");
            vastuuHenkilot.Rows.Add(2, "Maija Aaltola", "Rehtori", "Koulutus- ja opiskelijapalvelut", "maija-aaltola@omnia.fi", "050 384 9354");
            vastuuHenkilot.Rows.Add(2, "Kai Iivari", "Talousjohtaja", "Talous ja hankintapalvelut", "maija-aalola@omnia.fi", "050 384 9354");
            vastuuHenkilot.Rows.Add(2, "Päivi Korhonen", "Viestintäjohtaja", "Viestintä- ja markkinointipalvelut", "paivi.korhonen@omnia.fi", "040 126 7599");
            vastuuHenkilot.Rows.Add(3, "Pekka Tauriainen", "Rehtori", "", "pekka.tauriainen@vantaa.fi", "050 312 4514");
            vastuuHenkilot.Rows.Add(3, "Anne Heinonen", "Työelämäpalvelupäällikkö", "", "anne.heinonnen@vantaa.fi", "040 524 9048");
            vastuuHenkilot.Rows.Add(3, "Tuula Heinonen", "Yhteisten palveluiden päällikkö", "", "anne.heinonen@vantaa.fi", "040 524 1242");
            vastuuHenkilot.Rows.Add(4, "Tiina Halmevuo", "Kuntayhtymän johtaja", "Hallinto- ja johtamispalvelut", "tiina.halmevuo@keuda.fi", "050 336 9709");
            vastuuHenkilot.Rows.Add(4, "Anna Mari Leinonen", "Rehtori", "Hallinto", "annamari.leinonen@keuda.fi", "040 174 4523");
            vastuuHenkilot.Rows.Add(4, "Anne Vuorinen", "Johtaja", "Yritys_ ja elinvoimapalvelut", "anne.vuorinen@keuda.fi", "050 174 4523");
            vastuuHenkilot.Rows.Add(4, "Hanna Nyrönen", "Vestintä- ja markkinointipäällikkö", "anne.vuorinen@keuda.fi", "050 415 0974");
            vastuuHenkilot.Rows.Add(4, "Maarit Flinck", "Asianhallintapäällikkö", "Hallinto- ja johtamispalvelut", "maarit.flinck@keuda.fi", "0500 837 357");

        }

        private void vastuuhenkilo_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
