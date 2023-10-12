using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApi.Models;

namespace WebApi.Data
{
    public class HeladoData
    {
        public static bool Registrar(string sabor, string tamano, string precio)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sabor", sabor);
                cmd.Parameters.AddWithValue("@tamano", tamano);
                cmd.Parameters.AddWithValue("@precio", precio);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al registrar helado: " + ex.Message);
                    return false;
                }
            }
        }

        public static bool Modificar(int id, string sabor, string tamano, string precio)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@sabor", sabor);
                cmd.Parameters.AddWithValue("@tamano", tamano);
                cmd.Parameters.AddWithValue("@precio", precio);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                  
                    return true;
                }
            }
        }

        public static List<Helado> Listar()
        {
            List<Helado> oListaHelado = new List<Helado>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaHelado.Add(new Helado()
                            {
                                IdHelado = Convert.ToInt32(dr["IdHelado"]),
                                Sabor = dr["Sabor"].ToString(),
                                Tamano = dr["Tamano"].ToString(),
                                Precio = dr["Precio"].ToString()
                            });
                        }
                    }

                    return oListaHelado;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al listar helados: " + ex.Message);
                    return oListaHelado;
                }
            }
        }
    public static Helado Obtener(int id)
        {
            Helado oHelado = new Helado();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oHelado = new Helado()
                            {
                                IdHelado = Convert.ToInt32(dr["IdHelado"]),
                                Sabor = dr["Sabor"].ToString(),
                                Tamano = dr["Tamano"].ToString(),
                                Precio = dr["Precio"].ToString()
                            };
                        }
                    }

                    return oHelado;
                }
                catch (Exception ex)
                {
                    // Manejo de excepción: Registra el error y devuelve un objeto Helado vacío
                    Console.WriteLine("Error al obtener helado: " + ex.Message);
                    return oHelado;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    // Manejo de excepción: Registra el error y devuelve false
                    Console.WriteLine("Error al eliminar helado: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
