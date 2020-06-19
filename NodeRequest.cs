
using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Net;


namespace NodeUniverseDescrambler
{

    class NodeRequest
    {

        //////////////////////////////////////////////////////
        // HTTP REQUEST TO EXTRACT DATA
        //////////////////////////////////////////////////////
        private class HttpRequest
        {

            private string C_String;

            public virtual string C_STRING   {   get   {  return C_String;   }  set   {  C_String = value ;  }   }

            private StringBuilder _StringBuilder  = new StringBuilder();

          //  private WebProxy _WebProxy = new WebProxy();

            private WebClient _WebClient = new WebClient();

            private string m_setHTTP(string l_destination)
            {

                //WebProxy _WebProxy = new WebProxy("http://floridaproxy:9090");

                //_WebProxy.Credentials = CredentialCache.DefaultCredentials;

              //  WebRequest.DefaultWebProxy = _WebProxy;

               // WebClient _WebClient = new WebClient();

                 // StringBuilder _StringBuilder = new StringBuilder(_WebClient.DownloadString(l_destination));
                _StringBuilder.Clear();
                try
                {
                    _StringBuilder.Append(_WebClient.DownloadString(l_destination));
                }
                catch (WebException wb)
                {
                }
                _WebClient.Dispose();

                return _StringBuilder.ToString();

            }


            public void m_setHttpRequest(string l_destination)
            {
                C_String = m_setHTTP(l_destination);
            }

        };


        //////////////////////////////////////////////////////
        //CHOOSE NODE TYPE
        //////////////////////////////////////////////////////
        public class Node
        {

            private string C_string;
            
            private string C_destination1 = @"http://www.ncbi.nlm.nih.gov/protein?term=";
            private string C_destination2 = @"http://www.ncbi.nlm.nih.gov/pubmed/";
            private string C_destination3 = @"http://www.ncbi.nlm.nih.gov/sviewer/viewer.fcgi?val=";
            private string C_destination4 = @"&db=protein&dopt=genpept&extrafeat=984&fmt_mask=0&maxplex=1&retmode=html&log$=seqview&maxdownloadsize=1000000";

            public ArrayList C_ArrayList;

            public string C_pubMed;
            
 
            public Node(string l_pubmed, int l_type)
            {

                HttpRequest l_HttpRequest = new HttpRequest();

                C_pubMed = l_pubmed;

                if (l_type == 1)
                {
                    l_HttpRequest.m_setHttpRequest(C_destination1 + l_pubmed);
                    C_string = l_HttpRequest.C_STRING;

                    Page_Protein l_Page_Protein = new Page_Protein();
                    l_Page_Protein.Page_m_setProtein(C_string);
                    C_ArrayList = l_Page_Protein.C_ARRAYLIST;
                }
                else if (l_type == 2)
                {
                    l_HttpRequest.m_setHttpRequest(C_destination2 + l_pubmed);
                    C_string = l_HttpRequest.C_STRING;

                    Page_PubMed l_Page_PubMed = new Page_PubMed();
                    l_Page_PubMed.Page_m_setPubMed(C_string);
                    C_ArrayList = l_Page_PubMed.C_ARRAYLIST;
                }
                else if (l_type == 3)
                {
                    l_HttpRequest.m_setHttpRequest(C_destination3 + l_pubmed + C_destination4);
                    C_string = l_HttpRequest.C_STRING;

                    Page_ProteinResults l_Page_ProteinResults = new Page_ProteinResults();
                    l_Page_ProteinResults.Page_m_setProteinResults(C_string);
                    C_ArrayList = l_Page_ProteinResults.C_ARRAYLIST;
                }

            }

        };

    };

}
