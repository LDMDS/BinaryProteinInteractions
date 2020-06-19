
using System;
using System.Collections;
using System.Text;
using System.IO;


namespace NodeUniverseDescrambler
{

    //////////////////////////////////////////////////////
    //RETREIVE PROTEIN UNIVERSE
    //////////////////////////////////////////////////////
    class ProteinUniverse
    {
        private ArrayList C_ArrayList = new ArrayList() ;
        
        private StreamReader File_ProteinUniverse;

        
        public virtual ArrayList C_ARRAYLIST { get { return C_ArrayList; } set { C_ArrayList = value; } }


        public ProteinUniverse()
        {
            string line;

            File_ProteinUniverse = new StreamReader(@"C:\Documents and Settings\All Users\MYAPPLICATIONS\Matlab\Presentation\ProteinUniverse.txt");

            while ((line = File_ProteinUniverse.ReadLine()) != null)
            {
                C_ArrayList.Add(line.ToString().ToUpper());
            }
            
            File_ProteinUniverse.Close();
        }

    }

}
