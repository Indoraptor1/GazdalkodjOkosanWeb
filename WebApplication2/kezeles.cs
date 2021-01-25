using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace WebApplication2
{
    public class kezeles
    {
        public static void log(string id, string log)
        {
            RestClient logclient = new RestClient("http://localhost/gazdalkodj/");
            RestRequest logrequest = new RestRequest("/api1.php", Method.POST);
            logrequest.AddParameter("id", id);
            logrequest.AddParameter("action", "log");
            logrequest.AddParameter("log", log);
            var logclient1 = logclient.Execute(logrequest);
        }
        public static string penzhozzaad(string id, int mennyit)
        {


            int ujosszeg = 0;
            RestClient client = new RestClient("http://localhost/gazdalkodj/");
            RestRequest request = new RestRequest("/api1.php", Method.POST);
            request.AddParameter("id", id);
            request.AddParameter("action", "penz");
            var regist = client.Execute(request);
            dynamic regvalasz = JObject.Parse(regist.Content);

            int penz = regvalasz.response.penz;

                penz = penz - mennyit;
                ujosszeg = penz;

                RestClient client1 = new RestClient("http://localhost/gazdalkodj/");
                RestRequest request1 = new RestRequest("/api1.php", Method.POST);
                request1.AddParameter("id", id);
                request1.AddParameter("action", "penzcsere");
                request1.AddParameter("osszeg", penz);
                var regist1 = client1.Execute(request1);

                //log
                RestClient logclient = new RestClient("http://localhost/gazdalkodj/");
                RestRequest logrequest = new RestRequest("/api1.php", Method.POST);
                logrequest.AddParameter("id", id);
                logrequest.AddParameter("action", "log");
                logrequest.AddParameter("log", "+"+mennyit);
                var logclient1 = logclient.Execute(logrequest);

            
            return ujosszeg.ToString();
        }
        public static int penz(string id)
        {
            RestClient client = new RestClient("http://localhost/gazdalkodj/");
            RestRequest request = new RestRequest("/api1.php", Method.POST);
            request.AddParameter("id", id);
            request.AddParameter("action", "berendezes");
            var regist = client.Execute(request);
            dynamic regvalasz = JObject.Parse(regist.Content);
            int penz = regvalasz.response.penz;
            return penz;
        }
        public static int tartozas(string id)
        {
            RestClient client = new RestClient("http://localhost/gazdalkodj/");
            RestRequest request = new RestRequest("/api1.php", Method.POST);
            request.AddParameter("id", id);
            request.AddParameter("action", "berendezes");
            var regist = client.Execute(request);
            dynamic regvalasz = JObject.Parse(regist.Content);
            int tartozas = regvalasz.response.tartozas;
            return tartozas;
        }
        public static dynamic berendezes(string id)
        {
            RestClient client = new RestClient("http://localhost/gazdalkodj/");
            RestRequest request = new RestRequest("/api1.php", Method.POST);
            request.AddParameter("id", id);
            request.AddParameter("action", "berendezes");
            var regist = client.Execute(request);
            dynamic regvalasz = JObject.Parse(regist.Content);
            return regvalasz;
        }
        public static int minuspenz(string id, int penz_mennyit)
        {
            RestClient client = new RestClient("http://localhost/gazdalkodj/");
            RestRequest request = new RestRequest("/api1.php", Method.POST);
            request.AddParameter("id", id);
            request.AddParameter("action", "penz");
            var regist = client.Execute(request);
            dynamic regvalasz = JObject.Parse(regist.Content);

            int penz = regvalasz.response.penz;
            if (penz > penz_mennyit)
            {
                penz = penz - penz_mennyit;



                RestRequest request1 = new RestRequest("/api1.php", Method.POST);
                request1.AddParameter("id", id);
                request1.AddParameter("action", "penzcsere");
                request1.AddParameter("osszeg", penz);
                var regist1 = client.Execute(request1);

                //log

                RestRequest logrequest = new RestRequest("/api1.php", Method.POST);
                logrequest.AddParameter("id", id);
                logrequest.AddParameter("action", "log");
                logrequest.AddParameter("log", "-"+penz_mennyit);
                var logclient1 = client.Execute(logrequest);

            }
            else
                penz = -1;
            return penz;
        }
        public static void vasarlas(string id, string item)
        {
            string valasz = "hiba";
            RestClient logclient = new RestClient("http://localhost/gazdalkodj/");
            RestRequest logrequest = new RestRequest("/api1.php", Method.POST);
            logrequest.AddParameter("id", id);
            logrequest.AddParameter("action", "butorvasarlas");
            logrequest.AddParameter("item", item);
            var logclient1 = logclient.Execute(logrequest);
            dynamic regvalasz = JObject.Parse(logclient1.Content);
            
        }
        public static bool vanehaz(string id)
        {
            RestClient client = new RestClient("http://localhost/gazdalkodj/");
            RestRequest request = new RestRequest("/api1.php", Method.POST);
            request.AddParameter("id", id);
            request.AddParameter("action", "berendezes");
            var regist = client.Execute(request);
            dynamic regvalasz = JObject.Parse(regist.Content);
            string vanehaz = regvalasz.response.haz;
            if (vanehaz == "nincs")
            {
                return false;
            }
            else
                return true;
        }

        public static void tartozasfizetes(string id, int osszeg)
        {
            RestClient client = new RestClient("http://localhost/gazdalkodj/");
            RestRequest request = new RestRequest("/api1.php", Method.POST);
            request.AddParameter("id", id);
            request.AddParameter("action", "tartozasfizetes");
            request.AddParameter("osszeg", osszeg);

            var regist = client.Execute(request);
        }
        public static void hazvasarlas(string id)
        {
            RestClient logclient = new RestClient("http://localhost/gazdalkodj/");
            RestRequest logrequest = new RestRequest("/api1.php", Method.POST);
            logrequest.AddParameter("id", id);
            logrequest.AddParameter("action", "butorvasarlas");
            logrequest.AddParameter("item", "haz");
            var logclient1 = logclient.Execute(logrequest);
        }
    }
}