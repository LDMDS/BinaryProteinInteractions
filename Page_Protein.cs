
using System;
using System.Collections;
using System.Text;

namespace NodeUniverseDescrambler
{

    class Page_Protein
    {

        private string C_IndexOf;
        private string C_firstElement;
        private string C_secondElement;
        private ArrayList C_ArrayList;

        
        public virtual  string C_INDEXOF {  get {  return C_IndexOf;  }  set  { C_IndexOf = value;   }    }

        public virtual string C_FIRSTELEMENT { get { return C_firstElement; } set { C_firstElement = value; }   }

        public virtual string C_SECONDELEMENT { get { return C_secondElement; } set { C_secondElement = value; }    }

        public virtual ArrayList C_ARRAYLIST { get { return C_ArrayList; } set { C_ArrayList = value; }     }



        ///////////////////////////////////////////////////////
        //SCRAPE  AND REMOVE THE ID's
        ///////////////////////////////////////////////////////
        public virtual ArrayList m_extractXMLData(string l_C_string)
        {
            ArrayList l_ArrayList = new ArrayList();
            int i = 0;
            int k = 0;
            int l_end;
            int q = 0;
            string l_string;


            l_end = l_C_string.IndexOf(C_IndexOf);

            for (int x = 1; x + k < l_end; x++)
            {
                i = l_C_string.IndexOf(C_firstElement, k);

                if (i != -1)
                {
                    q = i + C_firstElement.Length;

                    k = l_C_string.IndexOf(C_secondElement, q);

                    l_string = l_C_string.Substring(q, (k - q));

                    if (l_ArrayList.Contains(l_string) == false)
                    {
                        l_ArrayList.Add(l_string);
                    }
                }
            }
            return l_ArrayList;
        }


        ///////////////////////////////////////////////////////
        //CREATE  NODE. AND SCRAPE 
        ///////////////////////////////////////////////////////
        public virtual ArrayList m_get_Page_Results(ArrayList l_ArrayList)
        {

            ArrayList Return_ArrayList = new ArrayList();

            foreach (string s in l_ArrayList)
            {
                NodeRequest.Node l_Node = new NodeRequest.Node( s , 3 );

                foreach (string k in l_Node.C_ArrayList)
                {
                    if (Return_ArrayList.Contains(k) == false)
                    {
                        Return_ArrayList.Add(k.ToString());
                    }
                }
            }
            return Return_ArrayList;

        }

        

        ///////////////////////////////////////////////////////
        //CREATE PROTEIN NODE. EXAMPLE BELOW
        //http://www.ncbi.nlm.nih.gov/protein?term=interleukin
        ///////////////////////////////////////////////////////        
        public void Page_m_setProtein(string l_string)
        {

            C_INDEXOF = "</html>";

            C_FIRSTELEMENT = "<p class=\"title\"><a href=\"/protein/";

            C_SECONDELEMENT = "\"";

            C_ARRAYLIST = m_extractXMLData(l_string);

            C_ARRAYLIST = m_get_Page_Results(C_ARRAYLIST);

        }

    }

}
