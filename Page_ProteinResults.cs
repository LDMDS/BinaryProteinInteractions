
using System;
using System.Collections;
using System.Text;


namespace NodeUniverseDescrambler
{

    class Page_ProteinResults : Page_Protein
    {
 

        public override ArrayList m_get_Page_Results(ArrayList l_ArrayList)
        {

            ArrayList Return_ArrayList = new ArrayList();

            foreach (string s in l_ArrayList)
            {
                NodeRequest.Node l_Node = new NodeRequest.Node( s , 2 ) ;

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
        // THIS RETRIEVES THE PDB'S RESULT. BELOW IS AN EXAMPLE
        //http://www.ncbi.nlm.nih.gov/sviewer/viewer.fcgi?val=33784&db=protein&dopt=genpept&extrafeat=984&fmt_mask=0&maxplex=1&retmode=html&log$=seqview&maxdownloadsize=1000000
        ///////////////////////////////////////////////////////
        public void Page_m_setProteinResults(string l_string)
        {
            C_INDEXOF = "ORIGIN";

            C_FIRSTELEMENT = "PUBMED   <a href=\"/pubmed/";

            C_SECONDELEMENT = "\">";

            C_ARRAYLIST = m_extractXMLData(l_string);

            C_ARRAYLIST = m_get_Page_Results(C_ARRAYLIST);
        }

    }

}
