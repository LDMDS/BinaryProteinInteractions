
using System;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Sql;

namespace NodeUniverseDescrambler
{


    class Program
    {

        private SqlConnection conn  = new SqlConnection(@"Server=USER-B3C425F480\SQLEXPRESS;DataBase=Hprd;Integrated Security=SSPI;MultipleActiveResultSets=True") ;


        public void m_sqlconnect(NodeRequest.Node l_Node, string l_string , int x)
        {

            int y = 0;

            conn.Open();
            
            ProteinUniverse _ProteinUniverse = new ProteinUniverse();


            foreach (string s in l_Node.C_ArrayList)
            {
                y = _ProteinUniverse.C_ARRAYLIST.IndexOf(s.ToString()) + 1; 

                Console.WriteLine( x.ToString() + "   " + y.ToString() + "   @Pdb: " + l_string.ToString() + "   @Substance: " + s.ToString() );

                SqlCommand cmd = new SqlCommand("Insert_Pdb_Substance_Interaction", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                 cmd.Parameters.Add(new SqlParameter( "@S1", x ) ) ;
                 cmd.Parameters.Add(new SqlParameter( "@S2", y ) ) ;
                cmd.Parameters.Add(new SqlParameter( "@Pdb", l_string));
                cmd.Parameters.Add(new SqlParameter( "@Substance", s.ToString()));

                cmd.ExecuteReader();
                
                cmd.Parameters.Clear();
                cmd.Dispose();

            }
            
           
            conn.Close();
        }


        //public void m_sqlconnectt()
        //{

        //    SqlConnection conn = null;

        //    conn = new SqlConnection("Server=(local);DataBase=Hprd;Integrated Security=SSPI;MultipleActiveResultSets=True");

        //    conn.Open();

        //   for(int i = 0 ; i < 5 ; i++ )
        //    {
        //        SqlCommand cmd = new SqlCommand("Insert_Pdb_Substance_Interaction", conn);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.Parameters.Add(new SqlParameter("@Pdb", "TEST"));
        //        cmd.Parameters.Add(new SqlParameter("@Substance", "TEST"));
        //        cmd.ExecuteReader();
        //        cmd.Parameters.Clear();
        //        cmd.Dispose();
        //    }
        //    conn.Close();
        //}



        static void Main(string[] args)
        {
            int x = 0;

            Program p = new Program();

            Console.WriteLine("...Running");

            ProteinUniverse _ProteinUniverse = new ProteinUniverse();

            foreach (String l_string in _ProteinUniverse.C_ARRAYLIST)
            {
                x = _ProteinUniverse.C_ARRAYLIST.IndexOf(l_string.ToString()) + 1;
              
                if (x > 3164)
                {
                    NodeRequest.Node Node1 = new NodeRequest.Node(l_string.ToString(), 1);

                    p.m_sqlconnect(Node1, l_string, x);
                }

            }

            Console.WriteLine("Finished");

            Console.ReadKey();

        }

    }

}
