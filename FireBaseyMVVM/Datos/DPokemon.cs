using System;
using System.Collections.Generic;
using System.Text;
using FireBaseyMVVM.Models;
using FireBaseyMVVM.Conexion;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Firebase.Database;

namespace FireBaseyMVVM.Datos
{
    public class DPokemon
    {
        public async Task InsertarPo(MPokemon parametros)
        {
            await CConexion.firebase.Child("Pokemon").PostAsync(new MPokemon()
            {
                Colorf = parametros.Colorf,
                Icono = parametros.Icono,
                Nombre = parametros.Nombre,
                Numero = parametros.Numero,
                Tipo = parametros.Tipo,
                Idpokemon = parametros.Idpokemon,
                ColorPoder = parametros.ColorPoder,
            }
                );
        }

        public async Task<ObservableCollection<MPokemon>> MostarPo()
        {
            //return (await CConexion.firebase.Child("Pokemon").OnceAsync<MPokemon>()).where(a=>a.Nombre!= "-").Select(item => new MPokemon
            //{
            //    Idpokemon = item.Key,
            //    Nombre = item.Object.Nombre,
            //    Tipo = item.Object.Tipo,
            //    Colorf = item.Object.Colorf,
            //    Icono = item.Object.Icono,
            //    ColorPoder = item.Object.ColorPoder,
            //    Numero = item.Object.Numero,
            //}
            //).ToList();

            // el ObservableCollection no permite los wheres en la consultas :(

            var data = await Task.Run(() => CConexion.firebase.Child("Pokemon").AsObservable<MPokemon>().AsObservableCollection());
            return data;

        }

        public async Task<List<MPokemon>> MostarPoLi()
        {
            return (await CConexion.firebase.Child("Pokemon").OnceAsync<MPokemon>()).Select(item => new MPokemon
            {
                Idpokemon = item.Key,
                Nombre = item.Object.Nombre,
                Tipo = item.Object.Tipo,
                Colorf = item.Object.Colorf,
                Icono = item.Object.Icono,
                ColorPoder = item.Object.ColorPoder,
                Numero = item.Object.Numero,
            }
            ).ToList();
        }


        public async Task EditarPo(MPokemon parametros)
        {
            var PokemonA = (await CConexion.firebase.Child("Pokemon").OnceAsync<MPokemon>()).Where(p => p.Key == parametros.Idpokemon).FirstOrDefault();

            await CConexion.firebase.Child("Pokemon").Child(PokemonA.Key).PutAsync(new MPokemon()
            {
                //Idpokemon = PokemonA.Key,
                Nombre = parametros.Nombre,
                Tipo = parametros.Tipo,
                Colorf = parametros.Colorf,
                Icono = parametros.Icono,
                ColorPoder = parametros.ColorPoder,
                Numero = parametros.Numero
            }
            );
        }

        public async Task  EliminarPo(String Idpo)
        {
            var EliPo = (await CConexion.firebase.Child("Pokemon").OnceAsync<MPokemon>()).Where(p => p.Key == Idpo).FirstOrDefault();
            Console.WriteLine(EliPo.Key);
            await CConexion.firebase.Child("Pokemon").Child(EliPo.Key).DeleteAsync();
        }

        public async Task <List<MPokemon>> BuscarIdPo(String Idpo)
        {
            return( await CConexion.firebase.Child("Pokemon").OnceAsync<MPokemon>()).Where(p => p.Key == Idpo).Select(item => new MPokemon
            {
                Idpokemon = item.Key,
                Nombre = item.Object.Nombre,
                Tipo = item.Object.Tipo,
                Colorf = item.Object.Colorf,
                Icono = item.Object.Icono,
                ColorPoder = item.Object.ColorPoder,
                Numero = item.Object.Numero,
            }).ToList();
        }

    }
}
