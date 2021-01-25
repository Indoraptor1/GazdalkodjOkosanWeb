using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;

namespace WebApplication2
{

    public partial class jatekos4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RestClient client = new RestClient("http://localhost/gazdalkodj/");
            RestRequest request = new RestRequest("/api1.php", Method.POST);
            request.AddParameter("id", "4");
            request.AddParameter("action", "berendezes"); 
            var regist = client.Execute(request);
            dynamic regvalasz = JObject.Parse(regist.Content);
            penzlabel.Text = "Pénzed: "+regvalasz.response.penz+" Ft";
            int penz = regvalasz.response.penz;
            int tartozas = regvalasz.response.tartozas;

            tartozaslabel.Text = "Az Ön tartozása: " + tartozas + " Ft";
            nincselegpenzed.Visible = false;

            //berendezesek
            dynamic berendezes = kezeles.berendezes("4");
            if(berendezes.response.mosogep == "nincs")
            {
                mososzobaimg.Enabled = true;
                mososzobaimg.ImageUrl = "~/pics/mososzobafekete.jpg";
            }
            else
            {
                mososzobaimg.Enabled = false;
                mososzobaimg.ImageUrl = "~/pics/mosokonyha.jpg";
            }
            //szobabutor
            if (berendezes.response.szobabutor == "nincs")
            {
                szobabutorimg.Enabled = true;
                szobabutorimg.ImageUrl = "~/pics/szobabutorfekete.jpg";
            }
            else
            {
                szobabutorimg.Enabled = false;
                szobabutorimg.ImageUrl = "~/pics/szobabutor.jpg";
            }

            //konyha
            if (berendezes.response.konyha == "nincs")
            {
                konyhaimg.Enabled = true;
                konyhaimg.ImageUrl = "~/pics/konyhafekete.jpg";
            }
            else
            {
                konyhaimg.Enabled = false;
                konyhaimg.ImageUrl = "~/pics/konyha.jpg";
            }

            //tv
            if (berendezes.response.tv == "nincs")
            {
                tvimg.Enabled = true;
                tvimg.ImageUrl = "~/pics/tvfekete.jpg";
            }
            else
            {
                tvimg.Enabled = false;
                tvimg.ImageUrl = "~/pics/tv.jpg";
            }
            //radio
            if (berendezes.response.radio == "nincs")
            {
                radioimg.Enabled = true;
                radioimg.ImageUrl = "~/pics/radiofekete.jpg";
            }
            else
            {
                radioimg.Enabled = false;
                radioimg.ImageUrl = "~/pics/radio.jpg";
            }

            //huto
            if (berendezes.response.huto == "nincs")
            {
                hutoimg.Enabled = true;
                hutoimg.ImageUrl = "~/pics/hutofekete.jpg";
            }
            else
            {
                hutoimg.Enabled = false;
                hutoimg.ImageUrl = "~/pics/huto.jpg";
            }
            //kerekpar
            if (berendezes.response.kerekpar == "nincs")
            {
                bicikliimg.Enabled = true;
                bicikliimg.ImageUrl = "~/pics/kerekparfekete.jpg";
            }
            else
            {
                bicikliimg.Enabled = false;
                bicikliimg.ImageUrl = "~/pics/kerekpar.jpg";
            }
            //porszivo
            if (berendezes.response.porszivo == "nincs")
            {
                porszivoimg.Enabled = true;
                porszivoimg.ImageUrl = "~/pics/porszivofekete.jpg";
            }
            else
            {
                porszivoimg.Enabled = false;
                porszivoimg.ImageUrl = "~/pics/porszivo.jpg";
            }
            //pingpong
            if (berendezes.response.pingpong == "nincs")
            {
                pinpongasztalimg.Enabled = true;
                pinpongasztalimg.ImageUrl = "~/pics/pingpongfekete.jpg";
            }
            else
            {
                pinpongasztalimg.Enabled = false;
                pinpongasztalimg.ImageUrl = "~/pics/pingpong.jpg";
            }
            


            //-----------------
            nincselegpenzedhaz.Visible = false;
            tartozasnincselegpenz.Visible = false;
            eloszorvegyelhazat.Visible = false;
            szamotirjbe.Visible = false;
            egyebosszegfizeteserror.Visible = false;
            if (berendezes.response.haz == "nincs")
            {
                hazvasarlasbtn.Enabled = true;
                hazvasarlasbtn.Text = "Ház vásárlása (300000 Ft)";
                hazvasarlasbtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#0066CC");
            }
            else
            {
                hazvasarlasbtn.Enabled = false;
                hazvasarlasbtn.Text = "Már van házad!";
                hazvasarlasbtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#006600");
            }

            if (kezeles.vanehaz("4"))
            {
                hazvasarlasbtn.Enabled = false;
                hazvasarlasbtn.Visible = false;

            }
            else
            {
                hazvasarlasbtn.Enabled = true;
                hazvasarlasbtn.Visible = true;
            }
          }

        protected void plus5000_Click(object sender, EventArgs e)
        {
            RestClient client = new RestClient("http://localhost/gazdalkodj/");
            RestRequest request = new RestRequest("/api1.php", Method.POST);
            request.AddParameter("id", "4");
            request.AddParameter("action", "penz");
            var regist = client.Execute(request);
            dynamic regvalasz = JObject.Parse(regist.Content);

            int penz = regvalasz.response.penz;
            penz = penz + 20000;
            penzlabel.Text = "Pénzed: " + penz + " Ft";

            RestClient client1 = new RestClient("http://localhost/gazdalkodj/");
            RestRequest request1 = new RestRequest("/api1.php", Method.POST);
            request1.AddParameter("id", "4");
            request1.AddParameter("action", "penzcsere");
            request1.AddParameter("osszeg", penz);
            var regist1 = client.Execute(request1);


            //log
            RestClient logclient = new RestClient("http://localhost/gazdalkodj/");
            RestRequest logrequest = new RestRequest("/api1.php", Method.POST);
            logrequest.AddParameter("id", "4");
            logrequest.AddParameter("action", "log");
            logrequest.AddParameter("log", "+20000");
            var logclient1 = client.Execute(logrequest);

        }

        protected void minus5000_Click(object sender, EventArgs e)
        {
            RestClient client = new RestClient("http://localhost/gazdalkodj/");
            RestRequest request = new RestRequest("/api1.php", Method.POST);
            request.AddParameter("id", "4");
            request.AddParameter("action", "penz");
            var regist = client.Execute(request);
            dynamic regvalasz = JObject.Parse(regist.Content);

            int penz = regvalasz.response.penz;
            if (penz > 4999)
            {
                penz = penz - 5000;
                penzlabel.Text = "Pénzed: " + penz + " Ft";

                RestClient client1 = new RestClient("http://localhost/gazdalkodj/");
                RestRequest request1 = new RestRequest("/api1.php", Method.POST);
                request1.AddParameter("id", "4");
                request1.AddParameter("action", "penzcsere");
                request1.AddParameter("osszeg", penz);
                var regist1 = client.Execute(request1);

                //log
                RestClient logclient = new RestClient("http://localhost/gazdalkodj/");
                RestRequest logrequest = new RestRequest("/api1.php", Method.POST);
                logrequest.AddParameter("id", "4");
                logrequest.AddParameter("action", "log");
                logrequest.AddParameter("log", "-5000");
                var logclient1 = client.Execute(logrequest);
                nincselegpenzed.Visible = false;
            }
            else
            {
                nincselegpenzed.Visible = true;
            }




        }

        protected void mososzobaimg_Click(object sender, ImageClickEventArgs e)
        {
            if (kezeles.vanehaz("4")) {
                if (kezeles.minuspenz("4", 20000) != -1)
                {

                    kezeles.vasarlas("4", "mosogep");
                    mososzobaimg.Enabled = false;
                    mososzobaimg.ImageUrl = "~/pics/mosokonyha.jpg";
                    kezeles.log("4", "Mosokonyha Vásárlása!");
                }
                else
                {
                    nincselegpenzedhaz.Visible = true;
                }
                penzlabel.Text = "Pénzed: " + kezeles.penz("4").ToString() + " Ft";
            }
            else
                eloszorvegyelhazat.Visible = true;
        }

        protected void plus1000_Click(object sender, EventArgs e)
        {
            
            string visszaad = kezeles.penzhozzaad("4", 1000);
            
        }

        protected void hazvasarlasbtn_Click(object sender, EventArgs e)
        {
            int fizetes = kezeles.minuspenz("4", 300000);
            if (fizetes != -1)
            {

                kezeles.hazvasarlas("4");
                pinpongasztalimg.Enabled = false;
                hazvasarlasbtn.Text = "Már van házad!";
                hazvasarlasbtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#006600");
                nincselegpenzed.Visible = false;
                kezeles.log("4", "Ház vásárlás");
            }
            else
            {
                nincselegpenzedhaz.Visible = true;
            }
            penzlabel.Text = "Pénzed: " + kezeles.penz("4").ToString() + " Ft";
        }

        protected void egyebosszegfizetesbtn_Click(object sender, EventArgs e)
        {
            int i;
            if (!int.TryParse(egyebtartozasfizetes.Text, out i))
            {
                egyebosszegfizeteserror.Visible = true;
                return;
            }
            egyebosszegfizeteserror.Visible = true;
            int egyebosszge = Convert.ToInt32(egyebtartozasfizetes.Text);

            dynamic berendezes = kezeles.berendezes("4");
            if (egyebosszge > Convert.ToInt32(berendezes.response.tartozas))
            {
                egyebosszge = Convert.ToInt32(berendezes.response.tartozas);
            }

            int fizetes = kezeles.minuspenz("4", egyebosszge);
            if (fizetes != -1)
            {
                

                kezeles.tartozasfizetes("4", egyebosszge);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sikeresen kifizettél " + egyebosszge + " Ft-t')", true);

                RestClient client = new RestClient("http://localhost/gazdalkodj/");
                RestRequest request = new RestRequest("/api1.php", Method.POST);
                request.AddParameter("id", "4");
                request.AddParameter("action", "berendezes");
                var regist = client.Execute(request);
                dynamic regvalasz = JObject.Parse(regist.Content);
                penzlabel.Text = "Pénzed: " + regvalasz.response.penz + " Ft";
                int penz = regvalasz.response.penz;
                int tartozas = regvalasz.response.tartozas;
                kezeles.log("4", "Tartozás fizetése: " + egyebosszge);
                tartozaslabel.Text = "Az Ön tartozása: " + tartozas + " Ft";
            }
        }

        protected void tartozasfizetes_Click(object sender, EventArgs e)
        {
            dynamic berendezes = kezeles.berendezes("4");
            int egyebosszge = Convert.ToInt32(berendezes.response.tartozas);
            int fizetes = kezeles.minuspenz("4", egyebosszge);
            if (fizetes != -1)
            {
               
                if (egyebosszge > Convert.ToInt32(berendezes.response.tartozas))
                {
                    egyebosszge = Convert.ToInt32(berendezes.response.tartozas);
                }

                kezeles.tartozasfizetes("4", egyebosszge);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sikeresen kifizettél " + egyebosszge + " Ft-t')", true);


                RestClient client = new RestClient("http://localhost/gazdalkodj/");
                RestRequest request = new RestRequest("/api1.php", Method.POST);
                request.AddParameter("id", "4");
                request.AddParameter("action", "berendezes");
                var regist = client.Execute(request);
                dynamic regvalasz = JObject.Parse(regist.Content);
                penzlabel.Text = "Pénzed: " + regvalasz.response.penz + " Ft";
                int penz = regvalasz.response.penz;
                int tartozas = regvalasz.response.tartozas;

                tartozaslabel.Text = "Az Ön tartozása: " + tartozas + " Ft";
                kezeles.log("4", "Tartozás fizetése: "+egyebosszge);
            }
        }

        protected void porszivoimg_Click(object sender, ImageClickEventArgs e)
        {
            int mennyibefaj = 15000;
            string id = "4";
            string itemname = "porszivo";
            string nemfeketeimg = "~/pics/porszivo.jpg";


            if (kezeles.vanehaz("4"))
            {
                if (kezeles.minuspenz("4", mennyibefaj) != -1)
                {

                    kezeles.vasarlas(id, itemname);
                    porszivoimg.Enabled = false;
                    porszivoimg.ImageUrl = nemfeketeimg;
                }
                else
                {
                    nincselegpenzedhaz.Visible = true;
                }
                penzlabel.Text = "Pénzed: " + kezeles.penz(id).ToString() + " Ft";
            }
            else
                eloszorvegyelhazat.Visible = true;
        }

        protected void tartozas20000_Click(object sender, EventArgs e)
        {
            
            int egyebosszge = 20000;

            dynamic berendezes = kezeles.berendezes("4");
            if (egyebosszge > Convert.ToInt32(berendezes.response.tartozas))
            {
                egyebosszge = Convert.ToInt32(berendezes.response.tartozas);
            }

            int fizetes = kezeles.minuspenz("4", egyebosszge);
            if (fizetes != -1)
            {


                kezeles.tartozasfizetes("4", egyebosszge);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sikeresen kifizettél " + egyebosszge + " Ft-t')", true);

                RestClient client = new RestClient("http://localhost/gazdalkodj/");
                RestRequest request = new RestRequest("/api1.php", Method.POST);
                request.AddParameter("id", "4");
                request.AddParameter("action", "berendezes");
                var regist = client.Execute(request);
                dynamic regvalasz = JObject.Parse(regist.Content);
                penzlabel.Text = "Pénzed: " + regvalasz.response.penz + " Ft";
                int penz = regvalasz.response.penz;
                int tartozas = regvalasz.response.tartozas;
                kezeles.log("4", "Tartozás fizetése: " + egyebosszge);
                tartozaslabel.Text = "Az Ön tartozása: " + tartozas + " Ft";
            }
            else
            {
                nincselegpenzedhaz.Visible = true;
            }
        }

        protected void szobabutorimg_Click(object sender, ImageClickEventArgs e)
        {
            if (kezeles.vanehaz("4"))
            {
                if (kezeles.minuspenz("4", 250000) != -1)
                {

                    kezeles.vasarlas("4", "szobabutor");
                    szobabutorimg.Enabled = false;
                    szobabutorimg.ImageUrl = "~/pics/szobabutor.jpg";
                    kezeles.log("4", "Szobabutor Vásárlása!");
                }
                else
                {
                    nincselegpenzedhaz.Visible = true;
                }
                penzlabel.Text = "Pénzed: " + kezeles.penz("4").ToString() + " Ft";
            }
            else
                eloszorvegyelhazat.Visible = true;
        }


        protected void konyhaimg_Click(object sender, ImageClickEventArgs e)
        {
            if (kezeles.vanehaz("4"))
            {
                if (kezeles.minuspenz("4", 150000) != -1)
                {

                    kezeles.vasarlas("4", "konyha");
                    konyhaimg.Enabled = false;
                    konyhaimg.ImageUrl = "~/pics/konyha.jpg";
                    kezeles.log("4", "Konyha Vásárlása!");
                }
                else
                {
                    nincselegpenzedhaz.Visible = true;
                }
                penzlabel.Text = "Pénzed: " + kezeles.penz("4").ToString() + " Ft";
            }
            else
                eloszorvegyelhazat.Visible = true;
        }

        protected void hutoimg_Click(object sender, ImageClickEventArgs e)
        {
            if (kezeles.vanehaz("4"))
            {
                if (kezeles.minuspenz("4", 40000) != -1)
                {

                    kezeles.vasarlas("4", "huto");
                    hutoimg.Enabled = false;
                    hutoimg.ImageUrl = "~/pics/huto.jpg";
                    kezeles.log("4", "Hútő Vásárlása!");
                }
                else
                {
                    nincselegpenzedhaz.Visible = true;
                }
                penzlabel.Text = "Pénzed: " + kezeles.penz("4").ToString() + " Ft";
            }
            else
                eloszorvegyelhazat.Visible = true;
        }

        protected void tvimg_Click(object sender, ImageClickEventArgs e)
        {
            if (kezeles.vanehaz("4"))
            {
                if (kezeles.minuspenz("4", 40000) != -1)
                {

                    kezeles.vasarlas("4", "tv");
                    tvimg.Enabled = false;
                    tvimg.ImageUrl = "~/pics/tv.jpg";
                    kezeles.log("4", "TV Vásárlása!");
                }
                else
                {
                    nincselegpenzedhaz.Visible = true;
                }
                penzlabel.Text = "Pénzed: " + kezeles.penz("4").ToString() + " Ft";
            }
            else
                eloszorvegyelhazat.Visible = true;
        }

        protected void radioimg_Click(object sender, ImageClickEventArgs e)
        {
            if (kezeles.vanehaz("4"))
            {
                if (kezeles.minuspenz("4", 20000) != -1)
                {

                    kezeles.vasarlas("4", "radio");
                    radioimg.Enabled = false;
                    radioimg.ImageUrl = "~/pics/radio.jpg";
                    kezeles.log("4", "Radio Vásárlása!");
                }
                else
                {
                    nincselegpenzedhaz.Visible = true;
                }
                penzlabel.Text = "Pénzed: " + kezeles.penz("4").ToString() + " Ft";
            }
            else
                eloszorvegyelhazat.Visible = true;
        }

        protected void bicikliimg_Click(object sender, ImageClickEventArgs e)
        {
            if (kezeles.vanehaz("4"))
            {
                if (kezeles.minuspenz("4", 20000) != -1)
                {

                    kezeles.vasarlas("4", "kerekpar");
                    bicikliimg.Enabled = false;
                    bicikliimg.ImageUrl = "~/pics/kerekpar.jpg";
                    kezeles.log("4", "Kerékpár Vásárlása!");
                }
                else
                {
                    nincselegpenzedhaz.Visible = true;
                }
                penzlabel.Text = "Pénzed: " + kezeles.penz("4").ToString() + " Ft";
            }
            else
                eloszorvegyelhazat.Visible = true;
        }

        protected void pinpongasztalimg_Click(object sender, ImageClickEventArgs e)
        {
            if (kezeles.vanehaz("4"))
            {
                if (kezeles.minuspenz("4", 50000) != -1)
                {

                    kezeles.vasarlas("4", "pingpong");
                    pinpongasztalimg.Enabled = false;
                    pinpongasztalimg.ImageUrl = "~/pics/pingpong.jpg";
                    kezeles.log("4", "PingPong Vásárlása!");
                }
                else
                {
                    nincselegpenzedhaz.Visible = true;
                }
                penzlabel.Text = "Pénzed: " + kezeles.penz("4").ToString() + " Ft";
            }
            else
                eloszorvegyelhazat.Visible = true;
        }

        protected void hozzaadasbutton_Click(object sender, EventArgs e)
        {
           int i;
            if (!int.TryParse(hozzaadastextbox.Text, out i))
            {
                szamotirjbe.Visible = true;
                return;
            }
            szamotirjbe.Visible = true;
            int egyebosszge = Convert.ToInt32(hozzaadastextbox.Text);

            RestClient client = new RestClient("http://localhost/gazdalkodj/");
            RestRequest request = new RestRequest("/api1.php", Method.POST);
            request.AddParameter("id", "4");
            request.AddParameter("action", "penz");
            var regist = client.Execute(request);
            dynamic regvalasz = JObject.Parse(regist.Content);

            int penz = regvalasz.response.penz;
            penz = penz + egyebosszge;
            penzlabel.Text = "Pénzed: " + penz + " Ft";

            RestClient client1 = new RestClient("http://localhost/gazdalkodj/");
            RestRequest request1 = new RestRequest("/api1.php", Method.POST);
            request1.AddParameter("id", "4");
            request1.AddParameter("action", "penzcsere");
            request1.AddParameter("osszeg", penz);
            var regist1 = client.Execute(request1);


            //log
            RestClient logclient = new RestClient("http://localhost/gazdalkodj/");
            RestRequest logrequest = new RestRequest("/api1.php", Method.POST);
            logrequest.AddParameter("id", "4");
            logrequest.AddParameter("action", "log");
            logrequest.AddParameter("log", "+"+egyebosszge);
            var logclient1 = client.Execute(logrequest);
        }

            protected void levonasbutton_Click(object sender, EventArgs e) {
            int i;
            if (!int.TryParse(levonastextbox.Text, out i))
            {
                szamotirjbe.Visible = true;
                return;
            }
            szamotirjbe.Visible = true;
            int egyebosszge = Convert.ToInt32(levonastextbox.Text);
            int valasz = kezeles.minuspenz("4", egyebosszge);
            if(valasz != -1)
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sikeresen kifizettél " + egyebosszge + " Ft-t')", true);
            penzlabel.Text = "Pénzed: " + valasz + " Ft";
        }
    }
    }
