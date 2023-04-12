 using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace FireBaseyMVVM.Conexion
{
    public class CConexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://mvvmc-eb7e3-default-rtdb.firebaseio.com/");
    }
}
