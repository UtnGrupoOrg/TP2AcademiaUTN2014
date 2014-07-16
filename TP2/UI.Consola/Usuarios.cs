using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Logic;
using Business.Entities;

namespace UI.Consola
{
    public class Usuarios
    {
        private UsuarioLogic _UsuarioNegocio;

        public UsuarioLogic UsuarioNegocio
        {
            get { return _UsuarioNegocio; }
            set { _UsuarioNegocio = value; }
        }

        public Usuarios()
        {
            UsuarioNegocio = new UsuarioLogic();
        }

        public void Menu() 
        {
            ConsoleKey op;
            do
            {
                Console.WriteLine("1- Listado General");
                Console.WriteLine("2- Consulta");
                Console.WriteLine("3- Agregar");
                Console.WriteLine("4- Modificar");
                Console.WriteLine("5- Eliminar");
                Console.WriteLine("6- Salir");
                
                op= Console.ReadKey().Key;
                switch (op){
                            case ConsoleKey.D1:
                                this.ListadoGeneral(); 
                                break;
                            case ConsoleKey.D2: 
                                this.Consultar(); 
                                break;
                            case ConsoleKey.D3: 
                                this.Agregar(); 
                                break;
                            case ConsoleKey.D4: 
                                this.Modificar();
                                break;
                            case ConsoleKey.D5: 
                                this.Eliminar(); 
                                break;
                            case ConsoleKey.D6: 
                                break;
                            default: 
                                Console.WriteLine("Ingrese opcion entre 1-6") ; 
                                break;
                            }           
            } while (op != ConsoleKey.D6);
            Console.ReadKey();
        }

        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave); // TODO eliminar en el futuro, ya que no va a estar almacenada en texto plano
            Console.WriteLine("\t\tEmail: {0}", usr.Email);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            Console.WriteLine();

        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese ID del usuario a eliminar");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException)
            {
                Console.WriteLine("La ID ingresada debe ser un numero entero");  
             
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese ID del usuario a modidicar");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                usuario= this.ModificarDatosDeUsuario(usuario);
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");          
            }
            catch (NullReferenceException)
            {
                Console.WriteLine();
                Console.WriteLine("No existe usuario con ese ID");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }


        }
        /// <summary>
        /// Pide y asigna las propiedades de usuario excepto ID y State.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        private Usuario ModificarDatosDeUsuario(Usuario usuario)
        {
            Console.Write("Ingrese nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("Ingrese Apeliido: ");
            usuario.Apellido = Console.ReadLine();
            Console.Write("Ingrese Nombre de Usuario");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("Ingrese Clave");
            usuario.Clave = Console.ReadLine();
            Console.Write("Ingrese Email");
            usuario.Email = Console.ReadLine();
            Console.Write("Ingrese Habilitacion de usuario (1-Si/Otro-No) : ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            return usuario;
        }
        
        public void Agregar()
        {
            Console.Clear();
            Usuario usuario = new Usuario();
            usuario = this.ModificarDatosDeUsuario(usuario);
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", usuario.ID);

        }

        public void Consultar()
        {
            

            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario a consultar");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException )
            {
                Console.WriteLine("La ID ingresada debe ser un numero entero");
 
            }

            catch (NullReferenceException)
            {
                Console.WriteLine("No existe usuario con ese ID");
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void ListadoGeneral()
        {
            Console.Clear();

            try
            {
                foreach (Usuario usr in UsuarioNegocio.GetAll())
                {
                    this.MostrarDatos(usr);
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
        }

        

    }
}
