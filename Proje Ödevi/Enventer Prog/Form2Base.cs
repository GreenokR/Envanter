using System.Collections.Generic;
using System.Data.SqlClient;

namespace Enventer_Prog
{
    public class Form2Base
    {
        SqlConnection baglantı = new SqlConnection();

        public Form2Base(SqlConnection baglantı)
        {
            this.baglantı = baglantı;
        }

        public override bool Equals(object obj)
        {
            return obj is Form2Base @base &&
                   EqualityComparer<SqlConnection>.Default.Equals(baglantı, @base.baglantı);
        }

        public override int GetHashCode()
        {
            return -946673605 + EqualityComparer<SqlConnection>.Default.GetHashCode(baglantı);
        }
    }
}