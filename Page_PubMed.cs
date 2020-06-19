
using System;
using System.Collections;
using System.Text;

namespace NodeUniverseDescrambler
{

    class Page_PubMed : Page_Protein
    {

        ///////////////////////////////////////////////////////
        //SCRAPE THE PUBMED .
        ///////////////////////////////////////////////////////
        private string m_extractXMLData2String(string l_string )
        {
            string l_abstract;
            int i;
            int k;

            i = l_string.IndexOf(C_FIRSTELEMENT);

            if (i != -1)
            {
                k = l_string.IndexOf(C_SECONDELEMENT, i);
                l_abstract = l_string.Substring(i, (k - i));
                return l_abstract.ToUpper();
            }

            return string.Empty;
        }



        private ArrayList m_str2Array(string l_abstract)
        {
            ArrayList l_ArrayList = new ArrayList();

            string[] words = l_abstract.Split(' ');

            foreach (string word in words)
            {
                l_ArrayList.Add(word);
            }

            return l_ArrayList;
        }


        ///////////////////////////////////////////////////////
        //DO RELATIONAL SEARCH OF KEYWORDS IN PUBMED AGAINST PROTEIN UNIVERSE
        ///////////////////////////////////////////////////////
        private ArrayList m_scrubData( ArrayList l_abstract )
        {
            ArrayList C_returnArray = new ArrayList();

            ProteinUniverse _ProteinUniverse = new ProteinUniverse();

            foreach ( String l_string in _ProteinUniverse.C_ARRAYLIST )
            {
                if (l_abstract.Contains( l_string ))
                {
                    C_returnArray.Add( l_string );
                }
             }
            return C_returnArray;
        }




        ///////////////////////////////////////////////////////
        //CREATE PUBMED NODE. EXAMPLE BELOW
        //http://www.ncbi.nlm.nih.gov/pubmed/6321163
        ///////////////////////////////////////////////////////
        public void Page_m_setPubMed( string l_string )
        {
     
            string C_String ; 

            C_FIRSTELEMENT= "<h3>Abstract</h3><p>";

            C_SECONDELEMENT = "</p>";

            C_String = m_extractXMLData2String(l_string);

            C_ARRAYLIST = m_str2Array(C_String) ;

            C_ARRAYLIST = m_scrubData(C_ARRAYLIST); 
            
        }
    }
}
