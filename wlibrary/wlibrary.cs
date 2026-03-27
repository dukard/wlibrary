using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using wlibrary1;
using quest_emailsender;
using quest_emailsender3;
using sms_library;
using System.IO;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Data.Odbc;
using System.Data.OleDb;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace wlibrary
{
    public class wfunciones
    {
        public DataTable dt;
        public bool sistema_global;
        public String error, cad_JSON, var_telefonos = "", var_sms = "", lacadena, lanissan, invords3 = "",mensaje="";
        public char prefijo;

        public bool login(String log, String pas)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Tuserstablets with (nolock) where login='" + log + "' and pass='" + pas + "'"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool logo(String marca)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Tagencias2 with (nolock) where agencia='" + marca + "'"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool fondo(String marca)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Tfondos with (nolock) where marca='" + marca + "'"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool modelos(String marca)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Tmodelos with (nolock) where marca='" + marca + "'"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool preguntas(String marca)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Tpreguntas with (nolock) where marca='" + marca + "' order by marca,tipo,posicion"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool preguntas2(String marca)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Tpreguntas2 with (nolock) where marca='" + marca + "' order by marca,tipo,posicion"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool respuestas(String marca)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Ttiposresp with (nolock) where clave in (select distinct claveresp from Tpreguntas with (nolock) where marca='" + marca + "')"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool login2(String log, String pas)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Tusersquesttablets with (nolock) where login='" + log + "' and pass='" + pas + "'"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool tener_fuente()
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select posicion,nomarch from lasfuentes2 with (nolock) order by posicion"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }


        public bool mostrar_lista(String marca, String agencia, String fecha)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                String latabla = "";


                if (marca == "NISSAN")
                {
                    if ((agencia == "SAN JERONIMO") || (agencia == "SAN JERONIMO LAREDO") || (agencia == "LAS AGUILAS") || (agencia == "TLALPAN") || (agencia == "TLALPAN LAREDO") || (agencia == "LA JOYA") || (agencia == "LA JOYA LAREDO") || (agencia == "LA JOYA CROSSING")) latabla = "Tfuentes";
                    else latabla = "Tfuentesgolfo";
                }
                else latabla = "Tfuentes";

                if (obj.show_sql("select * from " + latabla + " with (nolock) where marca='" + marca + "' and agencia='" + agencia + "' and fecha='" + fecha + "' order by id DESC"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool mostrar_lista2(String marca, String agencia, String fecha)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Tfuentes3 with (nolock) where marca='" + marca + "' and agencia='" + agencia + "' and fecha='" + fecha + "' order by id DESC"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool generar_pdf(String marca, String agencia)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select razon from trazonsocial with (nolock) where marca='" + marca + "' and lugaragen='" + agencia + "'"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        ///segunda consulta
                        if (obj.show_sql("select promo from Tpromomes with (nolock) where marca='" + marca + "'"))
                        {
                            if (obj.dt.Rows.Count < 1)
                            {
                                error = "Sin Datos";
                                obj.dt.Dispose();
                                obj.dt = null;
                                obj = null;
                                return false;
                            }
                            else
                            {
                                dt.Rows[0][0] += "%&" + obj.dt.Rows[0][0];
                                obj.dt.Dispose();
                                obj.dt = null;
                                obj = null;
                                return true;
                            }
                        }
                        else
                        {
                            error = obj.error;
                            obj.error = null;
                            obj = null;
                            return false;
                        }
                        //  segunda consulta
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        //metodo para prospectos de seminuevos        
        public bool generar_pdf2(String marca, String agencia)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select razon from trazonsocial with (nolock) where marca='" + marca + "' and lugaragen='" + agencia + "'"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        ///segunda consulta
                        if (obj.show_sql("select promo from Tpromomes with (nolock) where marca='" + marca + "'"))
                        {
                            if (obj.dt.Rows.Count < 1)
                            {
                                error = "Sin Datos";
                                obj.dt.Dispose();
                                obj.dt = null;
                                obj = null;
                                return false;
                            }
                            else
                            {
                                dt.Rows[0][0] += "%&" + obj.dt.Rows[0][0];
                                obj.dt.Dispose();
                                obj.dt = null;
                                obj = null;
                                return true;
                            }
                        }
                        else
                        {
                            error = obj.error;
                            obj.error = null;
                            obj = null;
                            return false;
                        }
                        //  segunda consulta
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool insert_prospectos(String marca, String agencia, String user, String nombre, String telefono, String email, String vendedor, String fuente, String fecha, String hora, String acuenta, String modelo, String clavevend, String emailvend)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                String latabla, cadena,golfito="";
                string[] pedaxos;

                if (marca == "NISSAN")
                {
                    if ((agencia == "SAN JERONIMO") || (agencia == "SAN JERONIMO LAREDO") || (agencia == "LAS AGUILAS") || (agencia == "TLALPAN") || (agencia == "TLALPAN LAREDO") || (agencia == "LA JOYA") || (agencia == "LA JOYA LAREDO") || (agencia == "LA JOYA CROSSING")) latabla = "Tfuentes";
                    else latabla = "Tfuentesgolfo";
                }
                else latabla = "Tfuentes";


                if (acuenta == "Si")
                {
                    string copia="",copiagerente="";
                    string mensaje = marca + "\n\n" + agencia + "\n\n" + user + "\n\n" + nombre + "\n\n" + telefono + "\n\n" + email + "\n\n" + vendedor + "\n\n" + fuente + "\n\n" + fecha + "\n\n" + hora + "\n\n" + acuenta + "\n\n" + modelo + "\n\n" + clavevend + "\n\n" + emailvend;

                    if ((marca == "KIA") && (agencia == "GONZALITOS"))
                    {
                        copia = "arebolloso@carone.com.mx";
                        copiagerente = "jiperez@carone.com.mx";
                    }
                    else if ((marca == "KIA") && (agencia == "SANTA CATARINA"))
                    {
                        copia = "atorresr@carone.com.mx";
                        copiagerente = "jiperez@carone.com.mx";
                    }
                    else if ((marca == "CHIREY") && (agencia == "FLETEROS"))
                    {
                        copia = "erodriguezc@carone.com.mx";
                    }
                    else if ((marca == "GREAT WALL") && (agencia == "GONZALITOS"))
                    {
                        copia = "erodriguezc@carone.com.mx";
                    }
                    else if ((marca == "OMODA") && (agencia == "GONZALITOS"))
                    {
                        copia = "mlunac@carone.com.mx";
                    }                    
                    else if ((marca == "VOLKSWAGEN") && (agencia == "GONZALITOS"))
                    {
                        copia = "cgomez@carone.com.mx";
                        copiagerente = "gperez@carone.com.mx";
                    }
                    else if ((marca == "GREAT WALL") && (agencia == "GONZALITOS"))
                    {
                        copia = "rsalazarg@carone.com.mx";
                    }

                        emailsender obj3 = new emailsender();
                    obj3.sender("alarma@carone.com.mx",copia, copiagerente, "caronesite@gmail.com", "Auto a Cuenta", mensaje, mensaje);
                }

                if (marca == "MERCEDES BENZ")
                {
                    pedaxos = Regex.Split(acuenta, "\\$\\!");
                    acuenta = pedaxos[0];
                    golfito = pedaxos[1];
                }

                //CODIGO PARA CUANDO HAY PROBLEMAS
                if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + user + "','" + nombre + "','" + telefono + "','" + email + "','" + vendedor + "','" + fuente + "','" + fecha + "','" + hora + "','" + acuenta + "','" + modelo + "','" + clavevend + "','" + emailvend + "'", latabla, ""))
                {
                    if (latabla == "Tfuentes")
                    {
                        if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + email + "','" + modelo + "','" + nombre + "','',''", "carta_check", ""))
                        {
                            if (golfito == "Si")
                            {
                                if (obj.show_sql("select MAX(id) from " + latabla + " with (nolock)"))
                                {
                                    if (obj.data("insert", "", "'" + obj.dt.Rows[0][0].ToString() + "','" + marca + "','" + agencia + "','" + nombre + "','" + telefono + "','" + email + "'", "golf", ""))
                                    {
                                        //
                                    }
                                    else
                                    {
                                        //
                                    }
                                }
                            }
                        }

                        cad_JSON = "Dato Archivado";
                        return true;
                    }
                }

                return false;

                /*---------------------------------------------------------  pinche trabajo deoquis
                ///////////sin email y sin telefono
                if ((email.Trim() == "") && (telefono.Trim() == ""))
                {
                    if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + user + "','" + nombre + "','" + telefono + "','" + email + "','" + vendedor + "','" + fuente + "','" + fecha + "','" + hora + "','" + acuenta + "','" + modelo + "','" + clavevend + "','" + emailvend + "'", latabla, ""))
                    {
                        if (latabla == "Tfuentes")
                        {
                            if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + email + "','" + modelo + "','" + nombre + "','',''", "carta_check", ""))
                            {
                                //
                            }
                        }

                        cad_JSON = "Dato Archivado";
                        return true;
                    }

                    return false;
                }     ///////////checo si es repetido por email
                else if ((email.Trim() != "") && (telefono.Trim() == ""))
                {
                    cadena = "select * from " + latabla + " with (nolock) where email='" + email + "' and marca='" + marca + "' and agencia='" + agencia + "'";

                    if (buscamelo(cadena))
                    {   //guardado
                        if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + user + "','" + nombre + "','" + telefono + "','" + email + "','" + vendedor + "','" + fuente + "','" + fecha + "','" + hora + "','" + acuenta + "','" + modelo + "','" + clavevend + "','" + emailvend + "'", latabla, ""))
                        {
                            if (latabla == "Tfuentes")
                            {
                                if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + email + "','" + modelo + "','" + nombre + "','',''", "carta_check", ""))
                                {
                                    //
                                }
                            }

                            cad_JSON = "Dato Archivado";
                            return true;
                        }

                        return false;
                        //end guardado
                    }
                    else
                    {
                        cad_JSON = mensaje;
                        return false;
                    }
                }     ///////////checo si es repetido por telefono
                else if ((email.Trim() == "") && (telefono.Trim() != ""))
                {
                    cadena = "select * from " + latabla + " with (nolock) where telefono='" + telefono + "' and marca='" + marca + "' and agencia='" + agencia + "'";

                    if (buscamelo(cadena))
                    {
                        //guardado
                        if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + user + "','" + nombre + "','" + telefono + "','" + email + "','" + vendedor + "','" + fuente + "','" + fecha + "','" + hora + "','" + acuenta + "','" + modelo + "','" + clavevend + "','" + emailvend + "'", latabla, ""))
                        {
                            if (latabla == "Tfuentes")
                            {
                                if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + email + "','" + modelo + "','" + nombre + "','',''", "carta_check", ""))
                                {
                                    //
                                }
                            }

                            cad_JSON = "Dato Archivado";
                            return true;
                        }

                        return false;
                        //end guardado
                    }
                    else
                    {
                        cad_JSON = mensaje;
                        return false;
                    }
                }
                else  ///////// cuando tiene email y telefono  checo por email
                {
                    cadena = "select * from " + latabla + " with (nolock) where email='" + email + "' and marca='" + marca + "' and agencia='" + agencia + "'";

                    if (buscamelo(cadena))
                    {   //guardado
                        if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + user + "','" + nombre + "','" + telefono + "','" + email + "','" + vendedor + "','" + fuente + "','" + fecha + "','" + hora + "','" + acuenta + "','" + modelo + "','" + clavevend + "','" + emailvend + "'", latabla, ""))
                        {
                            if (latabla == "Tfuentes")
                            {
                                if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + email + "','" + modelo + "','" + nombre + "','',''", "carta_check", ""))
                                {
                                    //
                                }
                            }

                            cad_JSON = "Dato Archivado";
                            return true;
                        }

                        return false;
                        //end guardado
                    }
                    else
                    {
                        cad_JSON = mensaje;
                        return false;
                    }
                }
                ------------------------------------------------------------------------*/



                /***********
                //toma de autos alert
                cadena = "select * from Tlogin_tomadeautos where agencias like '%" + marca + "-" + agencia + "%' or agencias='CORPORATIVO' or agencias='DIRECCION'";

                if (get_dato(cadena))
                {
                    int k;
                    String lostokens = "", devicetokens = "";
                    SMS_referencia.servicioSoapClient cliente = new SMS_referencia.servicioSoapClient();

                    for (k = 0; k < dt.Rows.Count; k++)
                    {
                        if (dt.Rows[k][10].ToString().Trim() == "ios")
                        {
                            if (dt.Rows[k][11].ToString().Trim() != "") lostokens += dt.Rows[k][11].ToString().Trim() + ",";
                        }
                        else if (dt.Rows[k][10].ToString().Trim() == "android")
                        {
                            if (dt.Rows[k][11].ToString().Trim() != "") devicetokens += dt.Rows[k][11].ToString().Trim() + ",";
                        }

                    }

                    if (lostokens != "") lostokens = lostokens.Substring(0, (lostokens.Length - 1));
                    if (devicetokens != "") devicetokens = devicetokens.Substring(0, (devicetokens.Length - 1));
                    cliente.RN_function2(lostokens, devicetokens);
                }

                //toma de autos alert
                ***********/


                /************************************************************************************************************************
                //checo si es repetido de doble click
                cadena = "select * from " + latabla + " with (nolock) where nombre='" + nombre + "' and vendedor='" + vendedor + "' and marca='" + marca + "' and agencia='" + agencia + "' and fecha='" + fecha + "' and hora='" + hora + "'";

                if (obj.show_sql(cadena))
                {
                    cad_JSON = "Dato Archivado";
                    return true;
                }
                else
                {
                    if (obj.error == "Sin Datos")
                    {
                        ///////////checo si es repetido por email
                        if (email.Trim() != "")
                        {
                            cadena = "select * from " + latabla + " with (nolock) where email='" + email + "' and marca='" + marca + "' and agencia='" + agencia + "'";

                            if (obj.show_sql(cadena))
                            {
                                cad_JSON = "Dato Archivado";
                                return true;
                            }
                            else
                            {
                                if (obj.error == "Sin Datos")
                                {
                                    if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + user + "','" + nombre + "','" + telefono + "','" + email + "','" + vendedor + "','" + fuente + "','" + fecha + "','" + hora + "','" + acuenta + "','" + modelo + "','" + clavevend + "','" + emailvend + "'", latabla, ""))
                                    {
                                        if (latabla == "Tfuentes")
                                        {
                                            if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + email + "','" + modelo + "','" + nombre + "','',''", "carta_check", ""))
                                            {
                                                //
                                            }
                                        }

                                        //toma de autos alert
                                        cadena = "select * from Tlogin_tomadeautos where agencias like '%" + marca + "-" + agencia + "%' or agencias='CORPORATIVO' or agencias='DIRECCION'";

                                        if (get_dato(cadena))
                                        {
                                            int k;
                                            String lostokens = "", devicetokens = "";
                                            SMS_referencia.servicioSoapClient cliente = new SMS_referencia.servicioSoapClient();

                                            for (k = 0; k < dt.Rows.Count; k++)
                                            {
                                                if (dt.Rows[k][10].ToString().Trim() == "ios")
                                                {
                                                    if (dt.Rows[k][11].ToString().Trim() != "") lostokens += dt.Rows[k][11].ToString().Trim() + ",";
                                                }
                                                else if (dt.Rows[k][10].ToString().Trim() == "android")
                                                {
                                                    if (dt.Rows[k][11].ToString().Trim() != "") devicetokens += dt.Rows[k][11].ToString().Trim() + ",";
                                                }

                                            }

                                            if (lostokens != "") lostokens = lostokens.Substring(0, (lostokens.Length - 1));
                                            if (devicetokens != "") devicetokens = devicetokens.Substring(0, (devicetokens.Length - 1));
                                            cliente.RN_function2(lostokens, devicetokens);
                                        }

                                        //toma de autos alert

                                        cad_JSON = "Dato Archivado";
                                        return true;
                                    }
                                    else
                                    {
                                        this.error = "Error: " + obj.error;
                                        return false;
                                    }
                                }
                                else
                                {
                                    this.error = "Error: " + obj.error;
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            //***********checo si es repetido por telefono
                            if (telefono.Trim() != "")
                            {
                                cadena = "select * from " + latabla + " with (nolock) where telefono='" + telefono + "' and marca='" + marca + "' and agencia='" + agencia + "'";

                                if (obj.show_sql(cadena))
                                {
                                    cad_JSON = "Dato Archivado";
                                    return true;
                                }
                                else
                                {
                                    if (obj.error == "Sin Datos")
                                    {
                                        if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + user + "','" + nombre + "','" + telefono + "','" + email + "','" + vendedor + "','" + fuente + "','" + fecha + "','" + hora + "','" + acuenta + "','" + modelo + "','" + clavevend + "','" + emailvend + "'", latabla, ""))
                                        {
                                            //toma de autos alert
                                            cadena = "select * from Tlogin_tomadeautos where agencias like '%" + marca + "-" + agencia + "%' or agencias='CORPORATIVO' or agencias='DIRECCION'";

                                            if (get_dato(cadena))
                                            {
                                                int k;
                                                String lostokens = "", devicetokens = "";
                                                SMS_referencia.servicioSoapClient cliente = new SMS_referencia.servicioSoapClient();

                                                for (k = 0; k < dt.Rows.Count; k++)
                                                {
                                                    if (dt.Rows[k][10].ToString().Trim() == "ios")
                                                    {
                                                        if (dt.Rows[k][11].ToString().Trim() != "") lostokens += dt.Rows[k][11].ToString().Trim() + ",";
                                                    }
                                                    else if (dt.Rows[k][10].ToString().Trim() == "android")
                                                    {
                                                        if (dt.Rows[k][11].ToString().Trim() != "") devicetokens += dt.Rows[k][11].ToString().Trim() + ",";
                                                    }

                                                }

                                                if (lostokens != "") lostokens = lostokens.Substring(0, (lostokens.Length - 1));
                                                if (devicetokens != "") devicetokens = devicetokens.Substring(0, (devicetokens.Length - 1));
                                                cliente.RN_function2(lostokens, devicetokens);
                                            }

                                            //toma de autos alert


                                            cad_JSON = "Dato Archivado";
                                            return true;
                                        }
                                        else
                                        {
                                            this.error = "Error: " + obj.error;
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        this.error = "Error: " + obj.error;
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + user + "','" + nombre + "','" + telefono + "','" + email + "','" + vendedor + "','" + fuente + "','" + fecha + "','" + hora + "','" + acuenta + "','" + modelo + "','" + clavevend + "','" + emailvend + "'", latabla, ""))
                                {
                                    //toma de autos alert
                                    cadena = "select * from Tlogin_tomadeautos where agencias like '%" + marca + "-" + agencia + "%' or agencias='CORPORATIVO' or agencias='DIRECCION'";

                                    if (get_dato(cadena))
                                    {
                                        int k;
                                        String lostokens = "", devicetokens = "";
                                        SMS_referencia.servicioSoapClient cliente = new SMS_referencia.servicioSoapClient();

                                        for (k = 0; k < dt.Rows.Count; k++)
                                        {
                                            if (dt.Rows[k][10].ToString().Trim() == "ios")
                                            {
                                                if (dt.Rows[k][11].ToString().Trim() != "") lostokens += dt.Rows[k][11].ToString().Trim() + ",";
                                            }
                                            else if (dt.Rows[k][10].ToString().Trim() == "android")
                                            {
                                                if (dt.Rows[k][11].ToString().Trim() != "") devicetokens += dt.Rows[k][11].ToString().Trim() + ",";
                                            }

                                        }

                                        if (lostokens != "") lostokens = lostokens.Substring(0, (lostokens.Length - 1));
                                        if (devicetokens != "") devicetokens = devicetokens.Substring(0, (devicetokens.Length - 1));
                                        cliente.RN_function2(lostokens, devicetokens);
                                    }

                                    //toma de autos alert

                                    cad_JSON = "Dato Archivado";
                                    return true;
                                }
                                else
                                {
                                    this.error = "Error: " + obj.error;
                                    return false;
                                }
                            }
                            //**********
                        }
                        /////////////                        
                    }
                    else
                    {
                        this.error = "Error: " + obj.error;
                        return false;
                    }
                }
                ***************************************************************************************/
            }
            catch (Exception er)
            {
                this.error = "Error: " + er.ToString();
                obj = null;
                return false;
            }
        }

        private bool buscamelo(string cadenasql)
        {
            wfunciones1 obj5 = new wfunciones1();
            try
            {
                if (obj5.show_sql(cadenasql))
                {
                    mensaje = "Error: Ya Registrado,  IDQUEST: " + obj5.dt.Rows[0][0].ToString();
                    return false;
                }
                else
                {
                    if (obj5.error == "Sin Datos")
                    {
                        mensaje = "no encontrado";
                        return true;
                    }
                    else
                    {
                        mensaje = "Error: " + obj5.error;
                        return false;
                    }
                }
            }
            catch (Exception er)
            {
                mensaje = "Error: " + er.ToString();
                return false;
            }
        }

        public void agregar_prospecto(string idquest, string marca, string agencia, string usuario, string nombre, string telefono, string email, string vendedor, string fuente, string fecha, string hora, string acuenta, string modelo, string clavevend, string emailvend)
        {
            wfunciones1 obj = new wfunciones1();
            String latabla, cadena;

            if (marca == "NISSAN")
            {
                if ((agencia == "SAN JERONIMO") || (agencia == "SAN JERONIMO LAREDO") || (agencia == "LAS AGUILAS") || (agencia == "TLALPAN") || (agencia == "TLALPAN LAREDO") || (agencia == "LA JOYA") || (agencia == "LA JOYA LAREDO") || (agencia == "LA JOYA CROSSING")) latabla = "Tfuentes";
                else latabla = "Tfuentesgolfo";
            }
            else latabla = "Tfuentes";

            if (obj.data("insert", "", "'" + idquest + "','" + marca + "','" + agencia + "','" +  usuario + "','" + nombre + "','" + telefono + "','" + email + "','" + vendedor + "','" + fuente + "','" + fecha + "','" + hora + "','" + acuenta + "','" + modelo + "','" + clavevend + "','" + emailvend + "',''", latabla, ""))
            {

            }
        }

        /*
        public bool insert_prospectos(String marca, String agencia, String user, String nombre, String telefono, String email, String vendedor, String fuente, String fecha, String hora, String acuenta, String modelo)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                //checo si es repetido de doble click
                String cadena = "select * from Tfuentes with (nolock) where nombre='" + nombre + "' and vendedor='" + vendedor + "' and marca='" + marca + "' and agencia='" + agencia + "' and fecha='" + fecha + "' and hora='" + hora + "'";

                if (obj.show_sql(cadena))
                {
                    cad_JSON = "Dato Archivado";
                    return true;
                }
                else
                {
                    if (obj.error == "Sin Datos")
                    {
                        ///////////checo si es repetido por email
                        if (email.Trim() != "")
                        {
                            cadena = "select * from Tfuentes with (nolock) where email='" + email + "' and marca='" + marca + "' and agencia='" + agencia + "'";

                            if (obj.show_sql(cadena))
                            {
                                cad_JSON = "Dato Archivado";
                                return true;
                            }
                            else
                            {
                                if (obj.error == "Sin Datos")
                                {
                                    if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + user + "','" + nombre + "','" + telefono + "','" + email + "','" + vendedor + "','" + fuente + "','" + fecha + "','" + hora + "','" + acuenta + "','" + modelo + "'", "Tfuentes", ""))
                                    {
                                        cad_JSON = "Dato Archivado";
                                        return true;
                                    }
                                    else
                                    {
                                        this.error = "Error: " + obj.error;
                                        return false;
                                    }
                                }
                                else
                                {
                                    this.error = "Error: " + obj.error;
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            //***********checo si es repetido por telefono
                            if (telefono.Trim() != "")
                            {
                                cadena = "select * from Tfuentes with (nolock) where telefono='" + telefono + "' and marca='" + marca + "' and agencia='" + agencia + "'";

                                if (obj.show_sql(cadena))
                                {
                                    cad_JSON = "Dato Archivado";
                                    return true;
                                }
                                else
                                {
                                    if (obj.error == "Sin Datos")
                                    {
                                        if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + user + "','" + nombre + "','" + telefono + "','" + email + "','" + vendedor + "','" + fuente + "','" + fecha + "','" + hora + "','" + acuenta + "','" + modelo + "'", "Tfuentes", ""))
                                        {
                                            cad_JSON = "Dato Archivado";
                                            return true;
                                        }
                                        else
                                        {
                                            this.error = "Error: " + obj.error;
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        this.error = "Error: " + obj.error;
                                        return false;
                                    }
                                }
                            }
                            else 
                            {
                                if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + user + "','" + nombre + "','" + telefono + "','" + email + "','" + vendedor + "','" + fuente + "','" + fecha + "','" + hora + "','" + acuenta + "','" + modelo + "'", "Tfuentes", ""))
                                {
                                    cad_JSON = "Dato Archivado";
                                    return true;
                                }
                                else
                                {
                                    this.error = "Error: " + obj.error;
                                    return false;
                                }
                            }
                            //**********
                        }
                        /////////////                        
                    }
                    else
                    {
                        this.error = "Error: " + obj.error;
                        return false;
                    }
                }
            }
            catch (Exception er)
            {
                this.error = "Error: " + er.ToString();
                obj = null;
                return false;
            }
        }*/

        public bool insert_prospectos2(String marca, String agencia, String user, String nombre, String telefono, String email, String vendedor, String fuente, String fecha, String hora, String acuenta, String modelo)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                String cadena;


                if (acuenta == "Si")
                {
                    string copia = "", copiagerente = "";
                    string mensaje = marca + "\n\n" + agencia + "\n\n" + user + "\n\n" + nombre + "\n\n" + telefono + "\n\n" + email + "\n\n" + vendedor + "\n\n" + fuente + "\n\n" + fecha + "\n\n" + hora + "\n\n" + acuenta + "\n\n" + modelo;

                    if ((marca == "VOLKSWAGEN") && (agencia == "GONZALITOS"))
                    {
                        copia = "cgomez@carone.com.mx";
                        copiagerente = "gperez@carone.com.mx";
                    }

                    emailsender obj3 = new emailsender();
                    obj3.sender("alarma@carone.com.mx", copia, copiagerente, "caronesite@gmail.com", "Auto a Cuenta", mensaje, mensaje);
                }

                if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + user + "','" + nombre + "','" + telefono + "','" + email + "','" + vendedor + "','" + fuente + "','" + fecha + "','" + hora + "','" + acuenta + "','" + modelo + "','',''", "Tfuentes3", ""))
                {
                    cad_JSON = "Dato Archivado";
                    return true;
                }
                else
                {
                    this.error = "Error: " + obj.error;
                    return false;
                }

                /************if (obj.show_sql("select * from Tfuentes3 with (nolock) where nombre='" + nombre + "' and vendedor='" + vendedor + "' and marca='" + marca + "' and agencia='" + agencia + "' and fecha='" + fecha + "' and hora='" + hora + "'"))
                {
                    cad_JSON = "Dato Archivado";
                    return true;
                }
                else
                {
                    if (obj.error == "Sin Datos")
                    {
                        ///////////checo si es repetido por email
                        if (email.Trim() != "")
                        {
                            cadena = "select * from Tfuentes3 with (nolock) where email='" + email + "' and marca='" + marca + "' and agencia='" + agencia + "'";

                            if (obj.show_sql(cadena))
                            {
                                cad_JSON = "Dato Archivado";
                                return true;
                            }
                            else
                            {
                                if (obj.error == "Sin Datos")
                                {
                                    if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + user + "','" + nombre + "','" + telefono + "','" + email + "','" + vendedor + "','" + fuente + "','" + fecha + "','" + hora + "','" + acuenta + "','" + modelo + "','',''", "Tfuentes3", ""))
                                    {
                                        cad_JSON = "Dato Archivado";
                                        return true;
                                    }
                                    else
                                    {
                                        this.error = "Error: " + obj.error;
                                        return false;
                                    }
                                }
                                else
                                {
                                    this.error = "Error: " + obj.error;
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            //***********checo si es repetido por telefono
                            if (telefono.Trim() != "")
                            {
                                cadena = "select * from Tfuentes3 with (nolock) where telefono='" + telefono + "' and marca='" + marca + "' and agencia='" + agencia + "'";

                                if (obj.show_sql(cadena))
                                {
                                    cad_JSON = "Dato Archivado";
                                    return true;
                                }
                                else
                                {
                                    if (obj.error == "Sin Datos")
                                    {
                                        if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + user + "','" + nombre + "','" + telefono + "','" + email + "','" + vendedor + "','" + fuente + "','" + fecha + "','" + hora + "','" + acuenta + "','" + modelo + "','',''", "Tfuentes3", ""))
                                        {
                                            cad_JSON = "Dato Archivado";
                                            return true;
                                        }
                                        else
                                        {
                                            this.error = "Error: " + obj.error;
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        this.error = "Error: " + obj.error;
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + user + "','" + nombre + "','" + telefono + "','" + email + "','" + vendedor + "','" + fuente + "','" + fecha + "','" + hora + "','" + acuenta + "','" + modelo + "','',''", "Tfuentes3", ""))
                                {
                                    cad_JSON = "Dato Archivado";
                                    return true;
                                }
                                else
                                {
                                    this.error = "Error: " + obj.error;
                                    return false;
                                }
                            }
                            //**********
                        }
                        /////////////                        
                    }
                    else
                    {
                        this.error = "Error: " + obj.error;
                        return false;
                    }
                }************************/
            }
            catch (Exception er)
            {
                this.error = "Error: " + er.ToString();
                obj = null;
                return false;
            }
        }

        public bool datos_cliente(String quien, String marca, String lugaragen, String data)
        {
            wfunciones1 obj = new wfunciones1();

            if (marca == "NISSAN")
            {
                if ((lugaragen == "SAN JERONIMO") || (lugaragen == "SAN JERONIMO LAREDO") || (lugaragen == "LAS AGUILAS") || (lugaragen == "TLALPAN") || (lugaragen == "TLALPAN LAREDO") || (lugaragen == "LA JOYA") || (lugaragen == "LA JOYA LAREDO") || (lugaragen == "LA JOYA CROSSING"))
                {
                    if (obj.conexion(quien, marca, lugaragen, data))
                    {
                        if (obj.dt.Rows.Count < 1)
                        {
                            error = "Vacio";
                            obj.dt.Dispose();
                            obj.dt = null;
                            obj = null;
                            return false;
                        }
                        else
                        {
                            dt = obj.dt.Copy();
                            obj.dt.Dispose();
                            obj.dt = null;
                            obj = null;
                            return true;
                        }
                    }
                    else
                    {
                        if (obj.error == "Error: No Abrió")
                        {
                            if (obj.conexion(quien, marca, lugaragen, data))
                            {
                                if (obj.dt.Rows.Count < 1)
                                {
                                    error = "Vacio";
                                    obj.dt.Dispose();
                                    obj.dt = null;
                                    obj = null;
                                    return false;
                                }
                                else
                                {
                                    dt = obj.dt.Copy();
                                    obj.dt.Dispose();
                                    obj.dt = null;
                                    obj = null;
                                    return true;
                                }
                            }
                            else
                            {
                                error = obj.error;
                                obj.error = null;
                                obj = null;
                                return false;
                            }
                        }
                        else
                        {
                            error = obj.error;
                            obj.error = null;
                            obj = null;
                            return false;
                        }
                    }
                }
                else
                {
                    if (obj.conexion(quien, marca, lugaragen, data))
                    {
                        lanissan = obj.lanissan;
                        return true;
                    }
                    else
                    {
                        error = "Error:";
                        return false;
                    }
                }
            }
            else
            {
                if (obj.conexion(quien, marca, lugaragen, data))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Vacio";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    if (obj.error == "Error: No Abrió")
                    {
                        if (obj.conexion(quien, marca, lugaragen, data))
                        {
                            if (obj.dt.Rows.Count < 1)
                            {
                                error = "Vacio";
                                obj.dt.Dispose();
                                obj.dt = null;
                                obj = null;
                                return false;
                            }
                            else
                            {
                                dt = obj.dt.Copy();
                                obj.dt.Dispose();
                                obj.dt = null;
                                obj = null;
                                return true;
                            }
                        }
                        else
                        {
                            error = obj.error;
                            obj.error = null;
                            obj = null;
                            return false;
                        }
                    }
                    else
                    {
                        error = obj.error;
                        obj.error = null;
                        obj = null;
                        return false;
                    }
                }
            }
        }

        public bool tabla_clientes(String quien, String marca, String lugaragen, String lalista, Boolean ventas_global)
        {
            wfunciones1 obj = new wfunciones1();
            if (obj.conexion2(quien, marca, lugaragen, lalista, ventas_global))
            {
                if (marca == "NISSAN")
                {
                    //lanissan = obj.lanissan;
                    return true;
                }
                else
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Vacio";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
            }
            else
            {
                error = obj.error;
                obj.error = null;
                obj = null;
                return false;
            }
        }

        public bool insert_encuestas(String marca, String agencia, String user, String tipoenc, String invord, String encuesta, String fecha, String hora)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                int i;
                String laencuesta = "", el_sql;
                string[] pedazos;
                pedazos = Regex.Split(encuesta, "%&");

                /******
                //if ((marca == "KIA")||(marca == "CHRYSLER")||(marca == "FIAT")||(marca == "MITSUBISHI")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "' and fecha='" + fecha + "' and hora='" + hora + "'";
                if ((marca == "KIA") || (marca == "FORD") || (marca == "NISSAN")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "' and fecha='" + fecha + "' and hora='" + hora + "'";
                else if ((marca == "CHRYSLER") || (marca == "FIAT") || (marca == "MITSUBISHI")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "'";
                else if ((marca == "CHEVROLET") && (agencia == "TLALPAN")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "' and fecha='" + fecha + "' and hora='" + hora + "'";
                else if ((marca == "CHEVROLET") && (agencia == "LAS BOMBAS")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "' and fecha='" + fecha + "' and hora='" + hora + "'";
                else if ((marca == "CHEVROLET") && (agencia == "RUIZ CORTINES")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "' and fecha='" + fecha + "' and hora='" + hora + "'";
                else if ((marca == "CHEVROLET") && (agencia == "NOGALAR")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "' and fecha='" + fecha + "' and hora='" + hora + "'";
                else if ((marca == "CHEVROLET") && (agencia == "CONCORDIA")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "' and fecha='" + fecha + "' and hora='" + hora + "'";
                else if ((marca == "CHEVROLET") && (agencia == "LAS TORRES")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "' and fecha='" + fecha + "' and hora='" + hora + "'";
                else if ((marca == "CHEVROLET") && (agencia == "ALLENDE")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "' and fecha='" + fecha + "' and hora='" + hora + "'";
                else if ((marca == "CHEVROLET") && (agencia == "UNIVERSIDAD")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "' and fecha='" + fecha + "' and hora='" + hora + "'";
                else el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord=" + invord + " and fecha='" + fecha + "' and hora='" + hora + "'";
                *****/

                if ((marca == "KIA") || (marca == "FORD") || (marca == "NISSAN") || (marca == "MG") || (marca == "CHIREY") || (marca == "JETOUR") || (marca == "OMODA")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "'";
                else if ((marca == "CHRYSLER") || (marca == "FIAT") || (marca == "MITSUBISHI")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "'";
                else if ((marca == "CHEVROLET") && (agencia == "TLALPAN")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "'";
                else if ((marca == "CHEVROLET") && (agencia == "LAS BOMBAS")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "'";
                else if ((marca == "CHEVROLET") && (agencia == "RUIZ CORTINES")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "'";
                else if ((marca == "CHEVROLET") && (agencia == "NOGALAR")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "'";
                else if ((marca == "CHEVROLET") && (agencia == "CONCORDIA")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "'";
                else if ((marca == "CHEVROLET") && (agencia == "LAS TORRES")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "'";
                else if ((marca == "CHEVROLET") && (agencia == "CADEREYTA")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "'";
                else if ((marca == "CHEVROLET") && (agencia == "ALLENDE")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "'";
                else if ((marca == "CHEVROLET") && (agencia == "UNIVERSIDAD")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "'";
                else el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "'";

                if (obj.show_sql(el_sql))
                {
                    cad_JSON = "Dato Archivado";  //dato repetido
                    return true;
                }
                else
                {
                    if (obj.error == "Sin Datos")
                    {
                        /*if (!chk_invord_repetido(marca, agencia, invord))
                        {
                            cad_JSON = "Dato Archivado";  //dato repetido
                            return true;
                        }*/

                        for (i = 0; i < 20; i++)
                        {
                            if (i < pedazos.Length)
                            {
                                if (pedazos[i].Length>200)
                                {
                                    pedazos[i] = pedazos[i].Substring(0, 199);
                                    laencuesta += "'" + pedazos[i] + "',"; 
                                }
                                else
                                { 
                                    laencuesta += "'" + pedazos[i] + "',";
                                }
                            }
                            else
                            {
                                laencuesta += "'',";
                            }
                        }
                        laencuesta = laencuesta.Substring(0, (laencuesta.Length - 1));


                        if ((marca == "KIA") || (marca == "CHRYSLER") || (marca == "FIAT") || (marca == "MITSUBISHI") || (marca == "FORD") || (marca == "NISSAN") || (marca == "MG") || (marca == "CHIREY") || (marca == "JETOUR") || (marca == "OMODA")) el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + 0 + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";
                        else if ((marca == "CHEVROLET") && (agencia == "TLALPAN")) el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + 0 + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";
                        else if ((marca == "CHEVROLET") && (agencia == "LAS BOMBAS")) el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + 0 + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";
                        else if ((marca == "CHEVROLET") && (agencia == "RUIZ CORTINES")) el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + 0 + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";
                        else if ((marca == "CHEVROLET") && (agencia == "NOGALAR")) el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + 0 + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";
                        else if ((marca == "CHEVROLET") && (agencia == "CONCORDIA")) el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + 0 + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";
                        else if ((marca == "CHEVROLET") && (agencia == "LAS TORRES")) el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + 0 + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";
                        else if ((marca == "CHEVROLET") && (agencia == "CADEREYTA")) el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + 0 + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";
                        else if ((marca == "CHEVROLET") && (agencia == "ALLENDE")) el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + 0 + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";
                        else if ((marca == "CHEVROLET") && (agencia == "UNIVERSIDAD")) el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + 0 + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";
                        else el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + int.Parse(invord) + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";

                        if (obj.data("insert", "", el_sql, "Tencuestas", ""))
                        {
                            if (obj.show_sql("select MAX(id) from Tencuestas with (nolock)"))
                            {
                                alarmas(marca, agencia, tipoenc, invord, encuesta, obj.dt.Rows[0][0].ToString(), fecha, hora);
                                cad_JSON = "Dato Archivado";
                                return true;
                            }
                            else
                            {
                                cad_JSON = "Dato Archivado";
                                return true;//error en correo, pero no en insertar encuesta
                            }
                        }
                        else
                        {
                            this.error = "Error: " + obj.error;
                            return false;
                        }
                    }
                    else
                    {
                        this.error = "Error: " + obj.error.ToString();
                        obj = null;
                        return false;
                    }
                }
            }
            catch (Exception er)
            {
                this.error = "Error: " + er.ToString();
                obj = null;
                return false;
            }
        }


        public bool insert_encuestashyp(String marca, String agencia, String user, String tipoenc, String invord, String encuesta, String fecha, String hora)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                int i;
                String laencuesta = "", el_sql;
                string[] pedazos;
                pedazos = Regex.Split(encuesta, "%&");

                if ((marca == "KIA") || (marca == "FORD") || (marca == "NISSAN")) el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "' and fecha='" + fecha + "' and hora='" + hora + "'";
                else if ((marca == "CHRYSLER") || (marca == "FIAT") || (marca == "MITSUBISHI")) el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "'";
                else if ((marca == "CHEVROLET") && (agencia == "TLALPAN")) el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "' and fecha='" + fecha + "' and hora='" + hora + "'";
                else if ((marca == "CHEVROLET") && (agencia == "LAS BOMBAS")) el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "' and fecha='" + fecha + "' and hora='" + hora + "'";
                else if ((marca == "CHEVROLET") && (agencia == "RUIZ CORTINES")) el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "' and fecha='" + fecha + "' and hora='" + hora + "'";
                else if ((marca == "CHEVROLET") && (agencia == "NOGALAR")) el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "' and fecha='" + fecha + "' and hora='" + hora + "'";
                else if ((marca == "CHEVROLET") && (agencia == "CONCORDIA")) el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "' and fecha='" + fecha + "' and hora='" + hora + "'";
                else if ((marca == "CHEVROLET") && (agencia == "LAS TORRES")) el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "' and fecha='" + fecha + "' and hora='" + hora + "'";
                else if ((marca == "CHEVROLET") && (agencia == "ALLENDE")) el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "' and fecha='" + fecha + "' and hora='" + hora + "'";
                else if ((marca == "CHEVROLET") && (agencia == "UNIVERSIDAD")) el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord2='" + invord + "' and fecha='" + fecha + "' and hora='" + hora + "'";
                else el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and usuario='" + user + "' and tipoenc='" + tipoenc + "' and invord=" + invord + " and fecha='" + fecha + "' and hora='" + hora + "'";

                if (obj.show_sql(el_sql))
                {
                    cad_JSON = "Dato Archivado";  //dato repetido
                    return true;
                }
                else
                {
                    if (obj.error == "Sin Datos")
                    {
                        if (!chk_invord_repetidohyp(marca, agencia, invord))
                        {
                            cad_JSON = "Dato Archivado";  //dato repetido
                            return true;
                        }

                        for (i = 0; i < 20; i++)
                        {
                            if (i < pedazos.Length) laencuesta += "'" + pedazos[i] + "',";
                            else laencuesta += "'',";
                        }
                        laencuesta = laencuesta.Substring(0, (laencuesta.Length - 1));

                        if ((marca == "KIA") || (marca == "CHRYSLER") || (marca == "FIAT") || (marca == "MITSUBISHI") || (marca == "FORD") || (marca == "NISSAN")) el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + 0 + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";
                        else if ((marca == "CHEVROLET") && (agencia == "TLALPAN")) el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + 0 + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";
                        else if ((marca == "CHEVROLET") && (agencia == "LAS BOMBAS")) el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + 0 + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";
                        else if ((marca == "CHEVROLET") && (agencia == "RUIZ CORTINES")) el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + 0 + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";
                        else if ((marca == "CHEVROLET") && (agencia == "NOGALAR")) el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + 0 + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";
                        else if ((marca == "CHEVROLET") && (agencia == "CONCORDIA")) el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + 0 + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";
                        else if ((marca == "CHEVROLET") && (agencia == "LAS TORRES")) el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + 0 + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";
                        else if ((marca == "CHEVROLET") && (agencia == "ALLENDE")) el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + 0 + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";
                        else if ((marca == "CHEVROLET") && (agencia == "UNIVERSIDAD")) el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + 0 + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";
                        else el_sql = "'" + marca + "','" + agencia + "','" + user + "','" + tipoenc + "'," + int.Parse(invord) + "," + laencuesta + ",'" + fecha + "','" + hora + "','" + invord + "'";

                        if (obj.data("insert", "", el_sql, "Tencuestashyp", ""))
                        {
                            if (obj.show_sql("select MAX(id) from Tencuestashyp with (nolock)"))
                            {
                                alarmas2(marca, agencia, tipoenc, invord, encuesta, obj.dt.Rows[0][0].ToString(), fecha, hora);
                                cad_JSON = "Dato Archivado";
                                return true;
                            }
                            else
                            {
                                cad_JSON = "Dato Archivado";
                                return true;//error en correo, pero no en insertar encuesta
                            }
                        }
                        else
                        {
                            this.error = "Error: " + obj.error;
                            return false;
                        }
                    }
                    else
                    {
                        this.error = "Error: " + obj.error.ToString();
                        obj = null;
                        return false;
                    }
                }
            }
            catch (Exception er)
            {
                this.error = "Error: " + er.ToString();
                obj = null;
                return false;
            }
        }



        private bool chk_invord_repetido(String marca, String agencia, String invord)
        {
            wfunciones1 obj_chk = new wfunciones1();
            String el_sql;

            if ((marca == "KIA") || (marca == "FORD") || (marca == "NISSAN")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and invord2='" + invord + "'";
            else if ((marca == "CHRYSLER") || (marca == "FIAT") || (marca == "MITSUBISHI")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and invord2='" + invord + "'";
            else if ((marca == "CHEVROLET") && (agencia == "TLALPAN")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and invord2='" + invord + "'";
            else if ((marca == "CHEVROLET") && (agencia == "LAS BOMBAS")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and invord2='" + invord + "'";
            else if ((marca == "CHEVROLET") && (agencia == "RUIZ CORTINES")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and invord2='" + invord + "'";
            else if ((marca == "CHEVROLET") && (agencia == "NOGALAR")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and invord2='" + invord + "'";
            else if ((marca == "CHEVROLET") && (agencia == "CONCORDIA")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and invord2='" + invord + "'";
            else if ((marca == "CHEVROLET") && (agencia == "LAS TORRES")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and invord2='" + invord + "'";
            else if ((marca == "CHEVROLET") && (agencia == "ALLENDE")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and invord2='" + invord + "'";
            else if ((marca == "CHEVROLET") && (agencia == "UNIVERSIDAD")) el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and invord2='" + invord + "'";
            else el_sql = "select * from Tencuestas where marca='" + marca + "' and agencia='" + agencia + "' and invord=" + invord;

            if (obj_chk.show_sql(el_sql))
            {
                return false;
            }
            else
            {
                if (obj_chk.error == "Sin Datos")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool chk_invord_repetidohyp(String marca, String agencia, String invord)
        {
            wfunciones1 obj_chk = new wfunciones1();
            String el_sql;

            if ((marca == "KIA") || (marca == "FORD") || (marca == "NISSAN")) el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and invord2='" + invord + "'";
            else if ((marca == "CHRYSLER") || (marca == "FIAT") || (marca == "MITSUBISHI")) el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and invord2='" + invord + "'";
            else if ((marca == "CHEVROLET") && (agencia == "TLALPAN")) el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and invord2='" + invord + "'";
            else if ((marca == "CHEVROLET") && (agencia == "LAS BOMBAS")) el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and invord2='" + invord + "'";
            else if ((marca == "CHEVROLET") && (agencia == "RUIZ CORTINES")) el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and invord2='" + invord + "'";
            else if ((marca == "CHEVROLET") && (agencia == "NOGALAR")) el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and invord2='" + invord + "'";
            else if ((marca == "CHEVROLET") && (agencia == "CONCORDIA")) el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and invord2='" + invord + "'";
            else if ((marca == "CHEVROLET") && (agencia == "LAS TORRES")) el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and invord2='" + invord + "'";
            else if ((marca == "CHEVROLET") && (agencia == "ALLENDE")) el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and invord2='" + invord + "'";
            else if ((marca == "CHEVROLET") && (agencia == "UNIVERSIDAD")) el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and invord2='" + invord + "'";
            else el_sql = "select * from Tencuestashyp where marca='" + marca + "' and agencia='" + agencia + "' and invord=" + invord;

            if (obj_chk.show_sql(el_sql))
            {
                return false;
            }
            else
            {
                if (obj_chk.error == "Sin Datos")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }




        private void alarmas(String marca, String agencia, String tipoenc, String invord, String encuesta, String idenc, String fecha, String hora)
        {
            int i, j, k, nopreg;
            Boolean alarma = false, salir = false;
            Boolean[] alarmas;
            String sql, loscorreos = "", aquien = "", sms_msg = "", asesor = "";
            String[] enc, respuestas, datos_client, datos_client2, enc_datcli;
            StringBuilder builder = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();
            StringBuilder builder3 = new StringBuilder();
            DataTable aux;
            //---------------------------
            wfunciones1 obj3 = new wfunciones1();
            int sec, minute, hour, day, month;


            sql = "select claveresp,pregunta from Tpreguntas with (nolock) where marca='" + marca + "' and tipo='" + tipoenc + "' order by posicion";
            if (get_dato(sql))
            {
                aux = dt.Copy();
                nopreg = dt.Rows.Count;
                sql = "select posicion,condalarma from Tpreguntas with (nolock) where marca='" + marca + "' and tipo='" + tipoenc + "' and condalarma <> '' order by posicion";
                if (get_dato(sql))
                {
                    enc = Regex.Split(encuesta, "%&");
                    alarmas = new Boolean[nopreg];
                    for (i = 0; i < dt.Rows.Count; i++)
                    {
                        for (j = 0; j < nopreg; j++)
                        {
                            if (dt.Rows[i][0].ToString() == (j + 1).ToString())
                            {
                                respuestas = dt.Rows[i][1].ToString().Split(',');
                                if (respuestas.Length == 1)
                                {
                                    if (respuestas[0].ToString() == enc[j].ToString())
                                    {
                                        alarma = true;
                                        alarmas[j] = true;
                                        break;
                                    }
                                }
                                else
                                {
                                    for (k = 0; k < respuestas.Length; k++)
                                    {
                                        if (respuestas[k].ToString() == enc[j].ToString())
                                        {
                                            alarma = true;
                                            alarmas[j] = true;
                                            salir = true;
                                            break;
                                        }
                                    }

                                    if (salir)
                                    {
                                        salir = false;
                                        break;
                                    }
                                }

                                respuestas = null;
                            } //if encontró posición de cond.
                        } //for para buscar posición de la cond
                    } //for para condiciones (dt)


                    if (alarma)
                    {
                        if (marca == "MERCEDES BENZ")
                        {
                            String tabla_encuesta = "";

                            builder.Append("<br><br><br>ENCUESTA ID: " + idenc + "<br><br># INVENTARIO/ORDEN: " + invord + "<br>");
                            builder.Append("<table cellpadding='5' cellspacing='0' border='0'>");


                            for (i = 0; i < nopreg; i++)
                            {
                                if (alarmas[i]) sql = "#FF0000";
                                else sql = "#006699";

                                builder.Append("<tr><td bgcolor='" + sql + "' align='left' style='font-family: Arial; font-weight: bold; color: #FFFFFF' width='800'>" + (i + 1) + ".- " + aux.Rows[i][1] + ":</td>");
                                builder.Append("<td bgcolor='#669999' align='left' style='font-family: Arial; color: #CCCCFF'  width='300'>" + enc[i] + extra(aux.Rows[i][0].ToString(), enc[i].ToString()) + "</td></tr>");
                                builder.Append("<tr colspan='2' bgcolor='#555555' height='1'></tr>");
                                tabla_encuesta += sql + "+" + (i + 1) + ".- " + aux.Rows[i][1] + "+" + enc[i] + "+" + aux.Rows[i][0].ToString() + "%&";
                            }

                            builder.Append("</table></center><br><br><br>");
                            sql = "select * from Talarmasemail where marc='" + marca + "' and agen='" + agencia + "'";
                            if (get_dato(sql))
                            {
                                if (dt.Rows.Count == 1)
                                {
                                    for (i = 3; i < dt.Columns.Count; i++)
                                    {
                                        if (dt.Rows[0][i].ToString().Trim() != "")
                                        {
                                            if (i == 4)
                                            {
                                                if (tipoenc == "venta") loscorreos += dt.Rows[0][4].ToString() + ",";
                                                else loscorreos += dt.Rows[0][5].ToString() + ",";
                                                i++;
                                            }
                                            else loscorreos += dt.Rows[0][i].ToString() + ",";
                                        }
                                    }
                                    loscorreos = loscorreos.Substring(0, (loscorreos.Length - 1));
                                    emailsender obj = new emailsender();
                                    obj.sender("alarma@carone.com.mx", loscorreos, "", "caronesite@gmail.com", "Alarma: Marca=" + marca + " Agencia=" + agencia + " id=" + idenc + " tipo=" + tipoenc, "", builder.ToString());
                                }
                            }

                            //===========================================================================
                            //===========================================================================
                            //DateTime hoy;
                            //hoy = DateTime.Now;
                            //obj3.data("insert", "", "'" + marca + "','" + agencia + "','" + tipoenc + "','" + idenc + "','" + no_invord + "','" + tabla_cliente + "','" + tabla_encuesta + "','" + hoy.ToString("dd/MM/yyyy") + "','" + hoy.ToString("HH:mm") + "'", "Talarmas", "");
                            obj3.data("insert", "", "'" + marca + "','" + agencia + "','" + tipoenc + "','" + idenc + "','" + invord + "','','" + tabla_encuesta + "','" + fecha + "','" + hora + "','" + asesor + "',''", "Talarmas", "");
                            obj3.data("insert", "", "'" + marca + "','" + agencia + "','" + tipoenc + "','" + idenc + "','" + invord + "','" + asesor + "','" + fecha + "'", "enc_vend", "");
                            //===========================================================================

                            ///end mercedes


                        }
                        else
                        {
                            if (datos_cliente(tipoenc, marca, agencia, invord))
                            {
                                if (marca == "NISSAN")
                                {
                                    if (!((agencia == "SAN JERONIMO") || (agencia == "SAN JERONIMO LAREDO") || (agencia == "LAS AGUILAS") || (agencia == "TLALPAN") || (agencia == "TLALPAN LAREDO") || (agencia == "LA JOYA") || (agencia == "LA JOYA LAREDO") || (agencia == "LA JOYA CROSSING")))
                                    {
                                        cad_JSON = lanissan;
                                        cad_JSON = cad_JSON.Replace("\\", "").Replace("\"", "");
                                        datos_client = Regex.Split(cad_JSON, "%&");
                                    }
                                    else
                                    {
                                        for (i = 0; i < (dt.Columns.Count - 1); i++)
                                        {
                                            cad_JSON += dt.Rows[0][i] + "%&";
                                        }

                                        cad_JSON += dt.Rows[0][i];
                                        dt.Dispose();
                                        cad_JSON = cad_JSON.Replace("\\", "").Replace("\"", "");
                                        datos_client = Regex.Split(cad_JSON, "%&");
                                    }
                                }
                                else
                                {
                                    for (i = 0; i < (dt.Columns.Count - 1); i++)
                                    {
                                        cad_JSON += dt.Rows[0][i] + "%&";
                                    }

                                    cad_JSON += dt.Rows[0][i];
                                    dt.Dispose();
                                    cad_JSON = cad_JSON.Replace("\\", "").Replace("\"", "");
                                    datos_client = Regex.Split(cad_JSON, "%&");
                                }

                                String marcados, tabla_cliente = "", tabla_encuesta = "", no_invord = "";
                                //if ((marca == "CHEVROLET") && (agencia == "TLALPAN")) marcados = "KIA";
                                //else if ((marca == "CHEVROLET") && (agencia == "LAS BOMBAS")) marcados = "KIA";
                                //else marcados = marca;

                                if (marca == "CHEVROLET")
                                {
                                    if (agencia == "UNIVERSIDAD") marcados = marca;
                                    else marcados = "KIA";
                                }
                                else marcados = marca;


                                sql = "select * from Tmodelos with (nolock) where marca='" + marcados + "'";
                                if (get_dato(sql))
                                {
                                    if (dt.Rows.Count == 1)
                                    {
                                        if (tipoenc == "venta") enc_datcli = dt.Rows[0][2].ToString().Split(',');
                                        else enc_datcli = dt.Rows[0][3].ToString().Split(',');

                                        builder.Append("<br><br><center>");
                                        builder.Append("<table cellpadding='5' cellspacing='0' border='0'>");
                                        builder.Append("<tr><td colspan='2' style='font-size:15px;background-color:#0C7FA8;color:#FFFFFF'>DATOS DEL CLIENTE:</td></tr>");
                                        for (i = 0; i < enc_datcli.Length; i++)
                                        {
                                            if (i < datos_client.Length)
                                            {
                                                builder.Append("<tr><td bgcolor='#990099' align='right' style='font-family: Arial; font-weight: bold; color: #FFFFFF' width='300'>" + enc_datcli[i] + ":</td>");
                                                builder.Append("<td bgcolor='#669999' align='left' style='font-family: Arial; color: #CCCCFF'  width='300'>" + datos_client[i] + "</td></tr>");
                                                if (i == 0) no_invord = datos_client[0];
                                                tabla_cliente += enc_datcli[i] + "+" + datos_client[i] + "%&";
                                            }
                                            else
                                            {
                                                builder.Append("<tr><td bgcolor='#990099' align='right' style='font-family: Arial; font-weight: bold; color: #FFFFFF' width='300'>" + enc_datcli[i] + ":</td>");
                                                builder.Append("<td bgcolor='#669999' align='left' style='font-family: Arial; color: #CCCCFF'  width='300'></td></tr>");
                                                tabla_cliente += enc_datcli[i] + "+" + "" + "%&";
                                            }
                                        }

                                        builder.Append("</table><br><br><br>ENCUESTA ID: " + idenc + "<br>");
                                        builder.Append("<table cellpadding='5' cellspacing='0' border='0'>");

                                        for (i = 0; i < nopreg; i++)
                                        {
                                            if (alarmas[i]) sql = "#FF0000";
                                            else sql = "#006699";

                                            builder.Append("<tr><td bgcolor='" + sql + "' align='left' style='font-family: Arial; font-weight: bold; color: #FFFFFF' width='800'>" + (i + 1) + ".- " + aux.Rows[i][1] + ":</td>");
                                            builder.Append("<td bgcolor='#669999' align='left' style='font-family: Arial; color: #CCCCFF'  width='300'>" + enc[i] + extra(aux.Rows[i][0].ToString(), enc[i].ToString()) + "</td></tr>");
                                            builder.Append("<tr colspan='2' bgcolor='#555555' height='1'></tr>");
                                            tabla_encuesta += sql + "+" + (i + 1) + ".- " + aux.Rows[i][1] + "+" + enc[i] + "+" + aux.Rows[i][0].ToString() + "%&";
                                        }

                                        builder.Append("</table></center><br><br><br>");



                                        //===========================================================================


                                        Boolean multimarca = false, sis_global = false, autoline = false;

                                        if (marca == "FORD") sis_global = true;
                                        else if (marca == "MG") sis_global = true;
                                        else if (marca == "CHIREY") sis_global = true;
                                        else if (marca == "JETOUR") sis_global = true;
                                        else if (marca == "OMODA") sis_global = true;
                                        else if (marca == "MERCEDES BENZ") autoline = true;
                                        else if (marca == "KIA") sis_global = true;
                                        else if (marca == "NISSAN") sis_global = true;
                                        else if (marca == "CHRYSLER") sis_global = true;
                                        else if (marca == "FIAT") sis_global = true;
                                        else if (marca == "MITSUBISHI") sis_global = true;
                                        else if ((marca == "CHEVROLET") && (agencia == "TLALPAN")) sis_global = true;
                                        else if ((marca == "CHEVROLET") && (agencia == "LAS BOMBAS")) sis_global = true;
                                        else if ((marca == "CHEVROLET") && (agencia == "RUIZ CORTINES")) sis_global = true;
                                        else if ((marca == "CHEVROLET") && (agencia == "NOGALAR")) sis_global = true;
                                        else if ((marca == "CHEVROLET") && (agencia == "CONCORDIA")) sis_global = true;
                                        else if ((marca == "CHEVROLET") && (agencia == "LAS TORRES")) sis_global = true;
                                        else if ((marca == "CHEVROLET") && (agencia == "ALLENDE")) sis_global = true;
                                        else if ((marca == "CHEVROLET") && (agencia == "UNIVERSIDAD")) sis_global = true;
                                        else multimarca = true;

                                        if (sis_global)
                                        {
                                            if (tipoenc == "venta")
                                            {
                                                //sms_msg = "inventario:" + datos_client[0] + "\n" + "modelo:" + datos_client[4] + "\n" + "color:" + datos_client[7] + "\n" + "cliente:" + datos_client[10] + "\n" + "vendedor:" + datos_client[14];
                                                asesor = datos_client[14];
                                            }
                                            else
                                            {
                                                //sms_msg = "orden:" + datos_client[0] + "\n" + "cliente:" + datos_client[2] + "\n" + "placas:" + datos_client[9] + "\n" + "color:" + datos_client[10] + "\n" + "modelo:" + datos_client[13] + "\n" + "recepcionista:" + datos_client[16];
                                                asesor = datos_client[16];
                                            }
                                        }
                                        else if (multimarca)
                                        {
                                            if (tipoenc == "venta")
                                            {
                                                //sms_msg = "inventario:" + datos_client[0] + "\n" + "modelo:" + datos_client[5] + "\n" + "color:" + datos_client[8] + "\n" + "cliente:" + datos_client[11] + "\n" + "asesor:" + datos_client[19];
                                                asesor = datos_client[20];
                                            }
                                            else
                                            {
                                                //sms_msg = "orden:" + datos_client[0] + "\n" + "cliente:" + datos_client[2] + "\n" + "modelo:" + datos_client[12] + "\n" + "recepcionista:" + datos_client[15];
                                                asesor = datos_client[15];
                                            }
                                        }
                                        else if (autoline)
                                        {
                                            //if (tipoenc == "venta") sms_msg = "";
                                            //else sms_msg = "";
                                        }


                                        //===========================================================================
                                        //===========================================================================
                                        //DateTime hoy;
                                        //hoy = DateTime.Now;
                                        //obj3.data("insert", "", "'" + marca + "','" + agencia + "','" + tipoenc + "','" + idenc + "','" + no_invord + "','" + tabla_cliente + "','" + tabla_encuesta + "','" + hoy.ToString("dd/MM/yyyy") + "','" + hoy.ToString("HH:mm") + "'", "Talarmas", "");
                                        obj3.data("insert", "", "'" + marca + "','" + agencia + "','" + tipoenc + "','" + idenc + "','" + no_invord + "','" + tabla_cliente + "','" + tabla_encuesta + "','" + fecha + "','" + hora + "','" + asesor + "',''", "Talarmas", "");
                                        obj3.data("insert", "", "'" + marca + "','" + agencia + "','" + tipoenc + "','" + idenc + "','" + no_invord + "','" + asesor + "','" + fecha + "'", "enc_vend", "");
                                        //===========================================================================


                                        sql = "select * from Talarmasemail where marc='" + marca + "' and agen='" + agencia + "'";
                                        if (get_dato(sql))
                                        {
                                            if (dt.Rows.Count == 1)
                                            {
                                                for (i = 3; i < dt.Columns.Count; i++)
                                                {
                                                    if (dt.Rows[0][i].ToString().Trim() != "")
                                                    {
                                                        if (i == 4)
                                                        {
                                                            if (tipoenc == "venta") loscorreos += dt.Rows[0][4].ToString() + ",";
                                                            else loscorreos += dt.Rows[0][5].ToString() + ",";
                                                            i++;
                                                        }
                                                        else loscorreos += dt.Rows[0][i].ToString() + ",";
                                                    }
                                                }
                                                loscorreos = loscorreos.Substring(0, (loscorreos.Length - 1));
                                                emailsender obj = new emailsender();
                                                obj.sender("alarma@carone.com.mx", loscorreos, "", "caronesite@gmail.com", "Alarma: Marca=" + marca + " Agencia=" + agencia + " id=" + idenc + " tipo=" + tipoenc, "", builder.ToString());
                                            }
                                        } //end sql4

                                    } //count ==1
                                } //end sql3
                            } //end datos clientes





                        }
                    }  ///end si hay alarma
                    else
                    {
                        // cuando no hay alarma
                        if (marca == "MERCEDES BENZ")
                        {
                            obj3.data("insert", "", "'" + marca + "','" + agencia + "','" + tipoenc + "','" + idenc + "','" + invord + "','','" + fecha + "'", "enc_vend", "");
                        }
                        else
                        {
                            if (datos_cliente(tipoenc, marca, agencia, invord))
                            {
                                if (marca == "NISSAN")
                                {
                                    if (!((agencia == "SAN JERONIMO") || (agencia == "SAN JERONIMO LAREDO") || (agencia == "LAS AGUILAS") || (agencia == "TLALPAN") || (agencia == "TLALPAN LAREDO") || (agencia == "LA JOYA") || (agencia == "LA JOYA LAREDO") || (agencia == "LA JOYA CROSSING")))
                                    {
                                        cad_JSON = lanissan;
                                        cad_JSON = cad_JSON.Replace("\\", "").Replace("\"", "");
                                        datos_client = Regex.Split(cad_JSON, "%&");
                                    }
                                    else
                                    {
                                        for (i = 0; i < (dt.Columns.Count - 1); i++)
                                        {
                                            cad_JSON += dt.Rows[0][i] + "%&";
                                        }

                                        cad_JSON += dt.Rows[0][i];
                                        dt.Dispose();
                                        cad_JSON = cad_JSON.Replace("\\", "").Replace("\"", "");
                                        datos_client = Regex.Split(cad_JSON, "%&");
                                    }
                                }
                                else
                                {
                                    for (i = 0; i < (dt.Columns.Count - 1); i++)
                                    {
                                        cad_JSON += dt.Rows[0][i] + "%&";
                                    }

                                    cad_JSON += dt.Rows[0][i];
                                    dt.Dispose();
                                    cad_JSON = cad_JSON.Replace("\\", "").Replace("\"", "");
                                    datos_client = Regex.Split(cad_JSON, "%&");
                                }

                                Boolean multimarca = false, sis_global = false, autoline = false;

                                if (marca == "FORD") sis_global = true;
                                else if (marca == "MG") sis_global = true;
                                else if (marca == "CHIREY") sis_global = true;
                                else if (marca == "JETOUR") sis_global = true;
                                else if (marca == "OMODA") sis_global = true;
                                else if (marca == "MERCEDES BENZ") autoline = true;
                                else if (marca == "KIA") sis_global = true;
                                else if (marca == "NISSAN") sis_global = true;
                                else if (marca == "CHRYSLER") sis_global = true;
                                else if (marca == "FIAT") sis_global = true;
                                else if (marca == "MITSUBISHI") sis_global = true;
                                else if ((marca == "CHEVROLET") && (agencia == "TLALPAN")) sis_global = true;
                                else if ((marca == "CHEVROLET") && (agencia == "LAS BOMBAS")) sis_global = true;
                                else if ((marca == "CHEVROLET") && (agencia == "RUIZ CORTINES")) sis_global = true;
                                else if ((marca == "CHEVROLET") && (agencia == "NOGALAR")) sis_global = true;
                                else if ((marca == "CHEVROLET") && (agencia == "CONCORDIA")) sis_global = true;
                                else if ((marca == "CHEVROLET") && (agencia == "LAS TORRES")) sis_global = true;
                                else if ((marca == "CHEVROLET") && (agencia == "ALLENDE")) sis_global = true;
                                else if ((marca == "CHEVROLET") && (agencia == "UNIVERSIDAD")) sis_global = true;
                                else multimarca = true;

                                if (sis_global)
                                {
                                    if (tipoenc == "venta")
                                    {
                                        //sms_msg = "inventario:" + datos_client[0] + "\n" + "modelo:" + datos_client[4] + "\n" + "color:" + datos_client[7] + "\n" + "cliente:" + datos_client[10] + "\n" + "vendedor:" + datos_client[14];
                                        asesor = datos_client[14];
                                    }
                                    else
                                    {
                                        //sms_msg = "orden:" + datos_client[0] + "\n" + "cliente:" + datos_client[2] + "\n" + "placas:" + datos_client[9] + "\n" + "color:" + datos_client[10] + "\n" + "modelo:" + datos_client[13] + "\n" + "recepcionista:" + datos_client[16];
                                        asesor = datos_client[16];
                                    }
                                }
                                else if (multimarca)
                                {
                                    if (tipoenc == "venta")
                                    {
                                        //sms_msg = "inventario:" + datos_client[0] + "\n" + "modelo:" + datos_client[5] + "\n" + "color:" + datos_client[8] + "\n" + "cliente:" + datos_client[11] + "\n" + "asesor:" + datos_client[19];
                                        asesor = datos_client[20];
                                    }
                                    else
                                    {
                                        //sms_msg = "orden:" + datos_client[0] + "\n" + "cliente:" + datos_client[2] + "\n" + "modelo:" + datos_client[12] + "\n" + "recepcionista:" + datos_client[15];
                                        asesor = datos_client[15];
                                    }
                                }
                                else if (autoline)
                                {
                                    //if (tipoenc == "venta") sms_msg = "";
                                    //else sms_msg = "";
                                }

                                obj3.data("insert", "", "'" + marca + "','" + agencia + "','" + tipoenc + "','" + idenc + "','" + datos_client[0] + "','" + asesor + "','" + fecha + "'", "enc_vend", "");


                            }  // end datos cliente
                        }
                    }// end cuando hay alarma


                    ///////carta
                    if ((tipoenc == "venta") && (marca == "VOLKSWAGEN") && (agencia == "GONZALITOS"))
                    {
                        if (datos_cliente(tipoenc, marca, agencia, invord))
                        {
                            cad_JSON = "";
                            for (i = 0; i < (dt.Columns.Count - 1); i++)
                            {
                                cad_JSON += dt.Rows[0][i] + "%&";
                            }

                            cad_JSON += dt.Rows[0][i];
                            dt.Dispose();
                            cad_JSON = cad_JSON.Replace("\\", "").Replace("\"", "");
                            datos_client2 = Regex.Split(cad_JSON, "%&");

                            builder2.Append("<div style='width:1000px;height:800px;background-color: #FFFFFF;background-image: url(https://i.ibb.co/G22xyvz/carta-servicio.jpg);background-repeat: no-repeat;background-size: 1100px 900px; padding: 50px;font-family: Arial, Helvetica, sans-serif;'><br/><br/>");
                            builder2.Append("Estimado cliente:&nbsp;&nbsp;&nbsp;<b>" + datos_client2[11] + "</b><br/><br/><br/><br/><br/>");
                            builder2.Append("Volkswagen Gonzalitos te quiere agradecer por la confianza y la decisión de adquirir tu Nuevo&nbsp;&nbsp;<b>" + datos_client2[5] + " " + datos_client2[7] + "</b>con nosotros, estamos seguros que superará todas tus expectativas y esperamos que lo disfrutes al máximo. <br/><br/>");
                            builder2.Append("<h3>¡Muchas Felicidades!</h3><br/><br/><br/>");
                            builder2.Append("Durante el proceso de entrega se te explico lo siguiente: <br/><br/>");
                            builder2.Append("•Plan de asistencia vial<br/>");
                            builder2.Append("•Garantía del Vehículo<br/>");
                            builder2.Append("•Seguro de robo de autopartes (si aplica)<br/>");
                            builder2.Append("•Explicación Técnica de funcionamiento del Auto<br/>");
                            builder2.Append("•Explicación de conexión de su sistema al celular de bluetooth<br/><br/>");
                            builder2.Append("De no haberle explicado algún punto anterior favor de enviar un correo a vgutierrez@carone.com.mx<br/><br/>");
                            builder2.Append("Para nosotros es un placer poder servirte y por ello estamos listos para recibirte en nuestro Taller de Servicio, recuerda que los mantenimientos son cada 15,000km y/o 12 meses, lo que ocurra primero.  Para agendar una cita de mantenimiento solo envía un whatsapp a este teléfono (81) 89 89 33 21 o envíanos un mail a citasvwgzz@carone.com.mx<br/><br/>");
                            builder2.Append("Tu opinión es muy importante para seguir mejorando cada día por lo que, dentro de los próximos 2 días, recibirás una encuesta online con el siguiente asunto y dirección:<br/><br/>");
                            builder2.Append("<center>Asunto: Encuesta de Satisfacción VW - J.D. Power<br/>");
                            builder2.Append("</center><br/><br/><br/> ");
                            builder2.Append("¡Ahora formas parte de la Familia Volkswagen Gonzalitos!<br/><br/><br/>"); 
                            builder2.Append("<table width='100%' cellpadding='0' cellspacing='0' border='0'>");
                            builder2.Append("<tr><td align='right'><b>Ana Irene Lara<br/>Gerente de Ventas</b></td>");
                            builder2.Append("<td align='right'><b>Miguel Ángel Sahagun Anaya<br/>Gerente de Ventas</b></td>");
                            builder2.Append("</tr></table>");
                            builder2.Append("</div>");

                            emailsender3 obj = new emailsender3();
                            sql = "select * from Talarmasemail where marc='" + marca + "' and agen='" + agencia + "'";
                            if (get_dato(sql))
                            {
                                if (dt.Rows.Count == 1)
                                {
                                    loscorreos = "";
                                    //if (dt.Rows[0][3].ToString() != "") loscorreos = dt.Rows[0][3].ToString() + ",";
                                    if (dt.Rows[0][4].ToString() != "") loscorreos += dt.Rows[0][4].ToString() + ",";
                                    //if (dt.Rows[0][6].ToString() != "") loscorreos += dt.Rows[0][6].ToString() + ",";
                                    loscorreos += "caronesite@gmail.com";
                                    aquien = datos_client2[13] + "," + datos_client2[14];
                                    emailsender3 obj2 = new emailsender3();
                                    obj2.sender("vwexperienciade10@carone.com.mx", aquien, "", loscorreos, "carta: agradecimiento volkswagen", "", builder2.ToString());
                                    //  crear ticket
                                    minute = DateTime.Now.Minute;
                                    hour = DateTime.Now.Hour;
                                    day = DateTime.Now.Day;
                                    month = DateTime.Now.Month;
                                    sec = DateTime.Now.Second;
                                    obj3.data("insert", "", "'" + adecuar(day) + "-" + adecuar(month) + "-" + DateTime.Now.Year.ToString() + "&" + adecuar(hour) + ":" + adecuar(minute) + ":" + adecuar(sec) + "','" + invord + "','" + idenc + "','si','" + aquien + "','" + marca + "','" + agencia + "','" + tipoenc + "','" + fecha + "','" + DateTime.Now.AddDays(2).ToString("dd/MM/yyyy") + "','" + hora + "'", "Ttickets8", "");
                                }
                            }
                        }
                    }
                    if ((tipoenc == "postventa") && (marca == "VOLKSWAGEN") && (agencia == "GONZALITOS"))
                    {
                        if (datos_cliente(tipoenc, marca, agencia, invord))
                        {
                            cad_JSON = "";
                            for (i = 0; i < (dt.Columns.Count - 1); i++)
                            {
                                cad_JSON += dt.Rows[0][i] + "%&";
                            }

                            cad_JSON += dt.Rows[0][i];
                            dt.Dispose();
                            cad_JSON = cad_JSON.Replace("\\", "").Replace("\"", "");
                            datos_client2 = Regex.Split(cad_JSON, "%&");

                            builder2.Append("<div style='width:1000px;height:800px;background-color: #FFFFFF;background-image: url(https://i.ibb.co/G22xyvz/carta-servicio.jpg);background-repeat: no-repeat;background-size: 1100px 900px; padding: 50px;font-family: Arial, Helvetica, sans-serif;'><br/><br/>");
                            builder2.Append("Estimado cliente:&nbsp;&nbsp;&nbsp;<b>" + datos_client2[2] + "</b><br/><br/><br/><br/><br/>");
                            builder2.Append("Por medio de la presente Car One Gonzalitos Quiere agredecer por su confianza y el habernos elegido como su concesionaria Volkswagen para el servicio de su <b>" + datos_client2[12] + " " + datos_client2[10] + "</b>.<br /><br /><br/>");
                            builder2.Append("En base a su experiencia en la última visita a nuestras instalaciones de taller, deseamos mejorar en nuestra calidad de servicio, es por esto que le pedimos nos haga saber si nuestros asesores le explicaron o bien le ofrecieron los siguientes conceptos:<br/><br/><br/>");
                            builder2.Append("1. En General Como fue el Servicio prestado por nuestro Concesionario.<br/>");
                            builder2.Append("2. Como fue el proceso de recepción y entrega de su vehículo.<br/>");
                            builder2.Append("3. Su Asesor le explico de manera detallada los trabajos realizados.<br/>");
                            builder2.Append("4. Como fue el trato y Valoración del personal de Servicio.<br/>");
                            builder2.Append("5. Cual es su Satisfacción en General de la Marca.<br/>");
                            builder2.Append("6. Sabia que su vehículo paso por un proceso de calidad del trabajo realizado esto antes de serle entregado.<br/><br/><br/>");
                            builder2.Append("En caso de que alguna de las respuestas sea negativa por favor ayudanos enviando un correo a <b>rmsalinas@carone.com.mx</b><br/><br/><br/>");
                            builder2.Append("usted es parte de la familia Car One Volkswagen Gonzalitos su opinión es muy importante es por esto que le pedimos nos ayude a contestar una encuesta la cual le llegará a su correo electrónico dentro de los próximos 2 dias, el dominio es:<br/><br/><br/>");
                            builder2.Append("<center>");
                            builder2.Append("<b>Asunto: Encuesta de satisfacción VW-JD.Power<br/>");
                            builder2.Append("Dirección: satisfaccion@jdpower-survey.com</b>");
                            builder2.Append("</center>");
                            builder2.Append("<br/><br/><br/>");
                            builder2.Append("Estamos a su entera disposición en nuestro taller de servicio (81) 8989-3321 o rsanchezm@carone.com.mx.");
                            builder2.Append("<br/><br/><br/>");
                            builder2.Append("<table width='100%' cellpadding='0' cellspacing='0' border='0'>");
                            builder2.Append("<tr><td align='right'><b>Ing. Rosendo Sanchez Mata<br/>Gerente de Servicio</b></td></tr>");
                            builder2.Append("</table>");
                            builder2.Append("</div>");


                            emailsender3 obj = new emailsender3();
                            sql = "select * from Talarmasemail where marc='" + marca + "' and agen='" + agencia + "'";
                            if (get_dato(sql))
                            {
                                if (dt.Rows.Count == 1)
                                {
                                    loscorreos = "";
                                    //if (dt.Rows[0][3].ToString() != "") loscorreos = dt.Rows[0][3].ToString() + ",";
                                    if (dt.Rows[0][5].ToString() != "") loscorreos += dt.Rows[0][5].ToString() + ",";
                                    //if (dt.Rows[0][6].ToString() != "") loscorreos += dt.Rows[0][6].ToString() + ",";
                                    loscorreos += "caronesite@gmail.com";
                                    aquien = datos_client2[3] + "," + datos_client2[4];
                                    emailsender3 obj2 = new emailsender3();
                                    obj2.sender("vwexperienciade10@carone.com.mx", aquien, "", loscorreos, "carta: agradecimiento volkswagen", "", builder2.ToString());
                                    //  crear ticket
                                    minute = DateTime.Now.Minute;
                                    hour = DateTime.Now.Hour;
                                    day = DateTime.Now.Day;
                                    month = DateTime.Now.Month;
                                    sec = DateTime.Now.Second;
                                    obj3.data("insert", "", "'" + adecuar(day) + "-" + adecuar(month) + "-" + DateTime.Now.Year.ToString() + "&" + adecuar(hour) + ":" + adecuar(minute) + ":" + adecuar(sec) + "','" + invord + "','" + idenc + "','si','" + aquien + "','" + marca + "','" + agencia + "','" + tipoenc + "','" + fecha + "','" + DateTime.Now.AddDays(2).ToString("dd/MM/yyyy") + "','" + hora + "'", "Ttickets8", "");
                                }
                            }
                        }
                    }
                    //if ((tipoenc == "venta") && (marca == "FORD") && (agencia == "VALLE"))
                    if ((marca == "FORD") && (agencia == "VALLE"))
                    {
                        if (datos_cliente(tipoenc, marca, agencia, invord))
                        {
                            cad_JSON = "";
                            for (i = 0; i < (dt.Columns.Count - 1); i++)
                            {
                                cad_JSON += dt.Rows[0][i] + "%&";
                            }

                            cad_JSON += dt.Rows[0][i];
                            dt.Dispose();
                            cad_JSON = cad_JSON.Replace("\\", "").Replace("\"", "");
                            datos_client2 = Regex.Split(cad_JSON, "%&");

                            if (datos_client2[12].Trim() != "")
                            {
                                builder2.Append("<center>");
                                builder2.Append("<table cellpadding='0' cellspacing='0' border='0' width='1000' height='767'>");
                                builder2.Append("<tr><td align='left'><img alt='' src='http://prospectos.carone.com.mx:8880/quest2/img/logo_group.png' /></td><td></td>");
                                builder2.Append("<td align='right'><img alt='' width='120' height='120'src='http://prospectos.carone.com.mx:8880/quest2/img/log9.png' /></td></tr>");
                                builder2.Append("<tr><td colspan='3' align='right'><br /><font size='4' face='arial' color='#063344'>Monterrey, NL " + DateTime.Now.ToString("dd/MM/yyyy") + "</font></td></tr>");
                                builder2.Append("<tr><td colspan='3' align='left'><h1><font face='arial'>Estimado " + datos_client2[10] + "</font></h1></td></tr>");
                                builder2.Append("<tr><td colspan='3' align='left'><font size='4' face='arial' color='#063344'><b>");
                                builder2.Append("Nuestra empresa Car One Valle SA de CV comprometido a su satisfacción total, le agradece el habernos elegido como su distribuidora para la compra");
                                builder2.Append(" de su unidad " + datos_client2[5] + " Modelo " + datos_client2[6] + " con número de serie " + datos_client2[1] + " ,  Por lo cual su opinión nos hace cada día buscar los mejores estándares de calidad con nuestra actitud y servicio de esta manera mantener su ");
                                builder2.Append("confianza.<br/><br/>");
                                builder2.Append("Reiterando nuevamente nuestro agradecimiento le recordamos que Ford Motor Company de México en los próximos días le enviará a su email una encuesta para comprobar sí ");
                                builder2.Append("cumplimos con sus expectativas, para nosotros es de suma importancia conocer su experiencia adquirida de nuestro servicio.<br/><br/>");
                                builder2.Append("En caso de tener alguna inquietud, favor de contactarnos al 89 89 30 71 (Atención a Clientes) o correo electrónico nlara@carone.com.mx.");
                                builder2.Append("</b></font></td></tr><tr><td><h2>Agradecemos de antemano su preferencia.</h2></td>");
                                builder2.Append("<td></td><td align='center'>Atentamente<br/><h2><u>Ing. Gerardo Cuervo Lozano</u></h2><font size='3'>Gerente General<br/>CAR ONE VALLE SA DE CV.</font></td>");
                                builder2.Append("</tr></table></center>");

                                emailsender obj = new emailsender();
                                obj.sender("alarma@carone.com.mx", datos_client2[12].Trim(), "", "caronesite@gmail.com,pfrausto@carone.com.mx", "BIENVENIDO A LA FAMILIA FORD", "", builder2.ToString());
                                //obj.sender("alarma@carone.com.mx", "caronesite@gmail.com", "", "caronesite@gmail.com", "carta: agradecimiento", "", builder2.ToString());
                            }
                        }
                    }


                    /**********
                    if (alarma)
                    {
                        try
                        {
                            sql = "select * from Tloginalarmas where agencias like '%" + marca + "-" + agencia + "%'";
                            if (get_dato(sql))
                            {
                                //SMS_referencia.servicioSoapClient cliente = new SMS_referencia.servicioSoapClient();
                                String telefonos = "", resultado;
                                if (sms_msg.Length > 159) sms_msg = sms_msg.Substring(0, 160);

                                for (i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (dt.Rows[i][6].ToString().Trim() != "") telefonos += dt.Rows[i][6].ToString().Trim() + ",";
                                }

                                telefonos = telefonos.Substring(0, (telefonos.Length - 1));
                                /////resultado = cliente.SMS_function("COM5", telefonos, sms_msg);
                                var_telefonos = telefonos;
                                var_sms = sms_msg;
                            }
                        }
                        catch (Exception er)
                        {
                            obj3.data("insert", "", er.ToString(), "logi", "");
                        }
                    }
                    ********/


                } //end sql2
            }  //end sql1      


        }

        private void alarmas2(String marca, String agencia, String tipoenc, String invord, String encuesta, String idenc, String fecha, String hora)
        {
            int i, j, k, nopreg;
            Boolean alarma = false, salir = false;
            Boolean[] alarmas;
            String sql, loscorreos = "", asesor = "";
            String[] enc, respuestas, datos_client, enc_datcli;
            StringBuilder builder = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();
            StringBuilder builder3 = new StringBuilder();
            DataTable aux;
            //---------------------------
            wfunciones1 obj3 = new wfunciones1();


            sql = "select claveresp,pregunta from Tpreguntas2 with (nolock) where marca='" + marca + "' and tipo='" + tipoenc + "' order by posicion";
            if (get_dato(sql))
            {
                aux = dt.Copy();
                nopreg = dt.Rows.Count;
                sql = "select posicion,condalarma from Tpreguntas2 with (nolock) where marca='" + marca + "' and tipo='" + tipoenc + "' and condalarma <> '' order by posicion";
                if (get_dato(sql))
                {
                    enc = Regex.Split(encuesta, "%&");
                    alarmas = new Boolean[nopreg];
                    for (i = 0; i < dt.Rows.Count; i++)
                    {
                        for (j = 0; j < nopreg; j++)
                        {
                            if (dt.Rows[i][0].ToString() == (j + 1).ToString())
                            {
                                respuestas = dt.Rows[i][1].ToString().Split(',');
                                if (respuestas.Length == 1)
                                {
                                    if (respuestas[0].ToString() == enc[j].ToString())
                                    {
                                        alarma = true;
                                        alarmas[j] = true;
                                        break;
                                    }
                                }
                                else
                                {
                                    for (k = 0; k < respuestas.Length; k++)
                                    {
                                        if (respuestas[k].ToString() == enc[j].ToString())
                                        {
                                            alarma = true;
                                            alarmas[j] = true;
                                            salir = true;
                                            break;
                                        }
                                    }

                                    if (salir)
                                    {
                                        salir = false;
                                        break;
                                    }
                                }

                                respuestas = null;
                            } //if encontró posición de cond.
                        } //for para buscar posición de la cond
                    } //for para condiciones (dt)


                    if (alarma)
                    {
                        if (marca == "MERCEDES BENZ")
                        {
                            String tabla_encuesta = "";

                            builder.Append("<br><br><br>ENCUESTA ID: " + idenc + "<br><br># INVENTARIO/ORDEN: " + invord + "<br>");
                            builder.Append("<table cellpadding='5' cellspacing='0' border='0'>");


                            for (i = 0; i < nopreg; i++)
                            {
                                if (alarmas[i]) sql = "#FF0000";
                                else sql = "#006699";

                                builder.Append("<tr><td bgcolor='" + sql + "' align='left' style='font-family: Arial; font-weight: bold; color: #FFFFFF' width='800'>" + (i + 1) + ".- " + aux.Rows[i][1] + ":</td>");
                                builder.Append("<td bgcolor='#669999' align='left' style='font-family: Arial; color: #CCCCFF'  width='300'>" + enc[i] + extra(aux.Rows[i][0].ToString(), enc[i].ToString()) + "</td></tr>");
                                builder.Append("<tr colspan='2' bgcolor='#555555' height='1'></tr>");
                                tabla_encuesta += sql + "+" + (i + 1) + ".- " + aux.Rows[i][1] + "+" + enc[i] + "+" + aux.Rows[i][0].ToString() + "%&";
                            }

                            builder.Append("</table></center><br><br><br>");
                            sql = "select * from Talarmasemail2 where marc='" + marca + "' and agen='" + agencia + "'";
                            if (get_dato(sql))
                            {
                                if (dt.Rows.Count == 1)
                                {
                                    for (i = 3; i < dt.Columns.Count; i++)
                                    {
                                        if (dt.Rows[0][i].ToString().Trim() != "")
                                        {
                                            if (i == 4)
                                            {
                                                if (tipoenc == "venta") loscorreos += dt.Rows[0][4].ToString() + ",";
                                                else loscorreos += dt.Rows[0][5].ToString() + ",";
                                                i++;
                                            }
                                            else loscorreos += dt.Rows[0][i].ToString() + ",";
                                        }
                                    }
                                    loscorreos = loscorreos.Substring(0, (loscorreos.Length - 1));
                                    emailsender obj = new emailsender();
                                    obj.sender("alarma@carone.com.mx", loscorreos, "", "caronesite@gmail.com", "Alarma HyP: Marca=" + marca + " Agencia=" + agencia + " id=" + idenc + " tipo=" + tipoenc, "", builder.ToString());
                                }
                            }

                            ///end mercedes

                        }
                        else
                        {
                            if (datos_cliente("postventa", marca, agencia, invord))
                            {
                                if (marca == "NISSAN")
                                {
                                    if (((agencia != "SAN JERONIMO") && (agencia != "SAN JERONIMO LAREDO") && (agencia != "LAS AGUILAS") && (agencia != "TLALPAN") && (agencia != "TLALPAN LAREDO") && (agencia != "LA JOYA") && (agencia != "LA JOYA LAREDO") && (agencia != "LA JOYA CROSSING")))
                                    {
                                        cad_JSON = lanissan;
                                        cad_JSON = cad_JSON.Replace("\\", "").Replace("\"", "");
                                        datos_client = Regex.Split(cad_JSON, "%&");
                                    }
                                    else
                                    {
                                        for (i = 0; i < (dt.Columns.Count - 1); i++)
                                        {
                                            cad_JSON += dt.Rows[0][i] + "%&";
                                        }

                                        cad_JSON += dt.Rows[0][i];
                                        dt.Dispose();
                                        cad_JSON = cad_JSON.Replace("\\", "").Replace("\"", "");
                                        datos_client = Regex.Split(cad_JSON, "%&");
                                    }
                                }
                                else
                                {
                                    for (i = 0; i < (dt.Columns.Count - 1); i++)
                                    {
                                        cad_JSON += dt.Rows[0][i] + "%&";
                                    }

                                    cad_JSON += dt.Rows[0][i];
                                    dt.Dispose();
                                    cad_JSON = cad_JSON.Replace("\\", "").Replace("\"", "");
                                    datos_client = Regex.Split(cad_JSON, "%&");
                                }

                                String marcados, tabla_cliente = "", tabla_encuesta = "", no_invord = "";
                                
                                if (marca == "CHEVROLET")
                                {
                                    if (agencia == "UNIVERSIDAD") marcados = marca;
                                    else marcados = "KIA";
                                }
                                else marcados = marca;


                                sql = "select * from Tmodelos with (nolock) where marca='" + marcados + "'";
                                if (get_dato(sql))
                                {
                                    if (dt.Rows.Count == 1)
                                    {
                                        if (tipoenc == "venta") enc_datcli = dt.Rows[0][2].ToString().Split(',');
                                        else enc_datcli = dt.Rows[0][3].ToString().Split(',');

                                        builder.Append("<br><br><center>");
                                        builder.Append("<table cellpadding='5' cellspacing='0' border='0'>");
                                        builder.Append("<tr><td colspan='2' style='font-size:15px;background-color:#0C7FA8;color:#FFFFFF'>DATOS DEL CLIENTE:</td></tr>");
                                        for (i = 0; i < enc_datcli.Length; i++)
                                        {
                                            if (i < datos_client.Length)
                                            {
                                                builder.Append("<tr><td bgcolor='#990099' align='right' style='font-family: Arial; font-weight: bold; color: #FFFFFF' width='300'>" + enc_datcli[i] + ":</td>");
                                                builder.Append("<td bgcolor='#669999' align='left' style='font-family: Arial; color: #CCCCFF'  width='300'>" + datos_client[i] + "</td></tr>");
                                                if (i == 0) no_invord = datos_client[0];
                                                tabla_cliente += enc_datcli[i] + "+" + datos_client[i] + "%&";
                                            }
                                            else
                                            {
                                                builder.Append("<tr><td bgcolor='#990099' align='right' style='font-family: Arial; font-weight: bold; color: #FFFFFF' width='300'>" + enc_datcli[i] + ":</td>");
                                                builder.Append("<td bgcolor='#669999' align='left' style='font-family: Arial; color: #CCCCFF'  width='300'></td></tr>");
                                                tabla_cliente += enc_datcli[i] + "+" + "" + "%&";
                                            }
                                        }

                                        builder.Append("</table><br><br><br>ENCUESTA ID: " + idenc + "<br>");
                                        builder.Append("<table cellpadding='5' cellspacing='0' border='0'>");

                                        for (i = 0; i < nopreg; i++)
                                        {
                                            if (alarmas[i]) sql = "#FF0000";
                                            else sql = "#006699";

                                            builder.Append("<tr><td bgcolor='" + sql + "' align='left' style='font-family: Arial; font-weight: bold; color: #FFFFFF' width='800'>" + (i + 1) + ".- " + aux.Rows[i][1] + ":</td>");
                                            builder.Append("<td bgcolor='#669999' align='left' style='font-family: Arial; color: #CCCCFF'  width='300'>" + enc[i] + extra(aux.Rows[i][0].ToString(), enc[i].ToString()) + "</td></tr>");
                                            builder.Append("<tr colspan='2' bgcolor='#555555' height='1'></tr>");
                                            tabla_encuesta += sql + "+" + (i + 1) + ".- " + aux.Rows[i][1] + "+" + enc[i] + "+" + aux.Rows[i][0].ToString() + "%&";
                                        }

                                        builder.Append("</table></center><br><br><br>");



                                        //===========================================================================


                                        Boolean multimarca = false, sis_global = false, autoline = false;

                                        if (marca == "FORD") sis_global = true;
                                        else if (marca == "MG") sis_global = true;
                                        else if (marca == "CHIREY") sis_global = true;
                                        else if (marca == "JETOUR") sis_global = true;
                                        else if (marca == "OMODA") sis_global = true;
                                        else if (marca == "MERCEDES BENZ") autoline = true;
                                        else if (marca == "KIA") sis_global = true;
                                        else if (marca == "NISSAN") sis_global = true;
                                        else if (marca == "CHRYSLER") sis_global = true;
                                        else if (marca == "FIAT") sis_global = true;
                                        else if (marca == "MITSUBISHI") sis_global = true;
                                        else if ((marca == "CHEVROLET") && (agencia == "TLALPAN")) sis_global = true;
                                        else if ((marca == "CHEVROLET") && (agencia == "LAS BOMBAS")) sis_global = true;
                                        else if ((marca == "CHEVROLET") && (agencia == "RUIZ CORTINES")) sis_global = true;
                                        else if ((marca == "CHEVROLET") && (agencia == "NOGALAR")) sis_global = true;
                                        else if ((marca == "CHEVROLET") && (agencia == "CONCORDIA")) sis_global = true;
                                        else if ((marca == "CHEVROLET") && (agencia == "LAS TORRES")) sis_global = true;
                                        else if ((marca == "CHEVROLET") && (agencia == "ALLENDE")) sis_global = true;
                                        else if ((marca == "CHEVROLET") && (agencia == "UNIVERSIDAD")) sis_global = true;
                                        else multimarca = true;

                                        if (sis_global)
                                        {
                                            if (tipoenc == "venta")
                                            {   
                                                asesor = datos_client[14];
                                            }
                                            else
                                            {                                             
                                                asesor = datos_client[16];
                                            }
                                        }
                                        else if (multimarca)
                                        {
                                            if (tipoenc == "venta")
                                            {                                             
                                                asesor = datos_client[20];
                                            }
                                            else
                                            {                                             
                                                asesor = datos_client[15];
                                            }
                                        }
                                        else if (autoline)
                                        {
                                            //
                                        }

                                        sql = "select * from Talarmasemail2 where marc='" + marca + "' and agen='" + agencia + "'";
                                        if (get_dato(sql))
                                        {
                                            if (dt.Rows.Count == 1)
                                            {
                                                for (i = 3; i < dt.Columns.Count; i++)
                                                {
                                                    if (dt.Rows[0][i].ToString().Trim() != "")
                                                    {
                                                        if (i == 4)
                                                        {
                                                            if (tipoenc == "venta") loscorreos += dt.Rows[0][4].ToString() + ",";
                                                            else loscorreos += dt.Rows[0][5].ToString() + ",";
                                                            i++;
                                                        }
                                                        else loscorreos += dt.Rows[0][i].ToString() + ",";
                                                    }
                                                }
                                                loscorreos = loscorreos.Substring(0, (loscorreos.Length - 1));
                                                emailsender obj = new emailsender();
                                                obj.sender("alarma@carone.com.mx", loscorreos, "", "caronesite@gmail.com", "Alarma HyP: Marca=" + marca + " Agencia=" + agencia + " id=" + idenc + " tipo=" + tipoenc, "", builder.ToString());
                                            }
                                        } //end sql4

                                    } //count ==1
                                } //end sql3
                            } //end datos clientes





                        }
                    }  ///end si hay alarma
                    else
                    {
                        // cuando no hay alarma
                    }
                } //end sql2
            }  //end sql1      


        }


        private String extra(String tipo, String respuesta)
        {
            String extra = "";

            if (tipo == "5b")
            {
                switch (respuesta)
                {
                    case "Totalmente Satisfecho": extra = "1"; break;
                    case "Muy Satisfecho": extra = "2"; break;
                    case "Satisfecho": extra = "3"; break;
                    case "Poco Satisfecho": extra = "4"; break;
                    case "Nada Satisfecho": extra = "5"; break;
                    default: extra = ""; break;
                }

                if (extra != "") extra = "<br /><img src='http://prospectos.carone.com.mx:8880/quest2/img/resp/face" + extra + ".png' width='50' height='50' alt='' border='' />";
                return extra;
            }
            else if (tipo == "5v")
            {
                switch (respuesta)
                {
                    case "Completamente Satisfecho": extra = "1"; break;
                    case "Muy Satisfecho": extra = "5"; break;
                    case "Algo Satisfecho": extra = "5"; break;
                    case "Un Poco Satisfecho": extra = "5"; break;
                    case "Nada Satisfecho": extra = "5"; break;
                    default: extra = ""; break;
                }

                if (extra != "") extra = "<br /><img src='http://prospectos.carone.com.mx:8880/quest2/img/resp/face" + extra + ".png' width='50' height='50' alt='' border='' />";
                return extra;
            }
            else if (tipo == "5t")
            {
                switch (respuesta)
                {
                    case "Excelente": extra = "1"; break;
                    case "Muy Buena": extra = "2"; break;
                    case "Buena": extra = "3"; break;
                    case "Regular": extra = "4"; break;
                    case "Mala": extra = "5"; break;
                    default: extra = ""; break;
                }

                if (extra != "") extra = "<br /><img src='http://prospectos.carone.com.mx:8880/quest2/img/resp/face" + extra + ".png' width='50' height='50' alt='' border='' />";
                return extra;
            }
            else if (tipo == "5w")
            {
                switch (respuesta)
                {
                    case "Nada Satisfecho": extra = "5"; break;
                    case "Un Poco Satisfecho": extra = "4"; break;
                    case "Algo Satisfecho": extra = "3"; break;
                    case "Muy Satisfecho": extra = "2"; break;
                    case "Completamente Satisfecho": extra = "1"; break;
                    default: extra = "1"; break;
                }

                if (extra != "") extra = "<br /><img src='http://prospectos.carone.com.mx:8880/quest2/img/resp/face" + extra + ".png' width='50' height='50' alt='' border='' />";
                return extra;
            }
            else if (tipo == "6b")
            {
                switch (respuesta)
                {
                    case "Nada Satisfecho": extra = "5"; break;
                    case "Un Poco Satisfecho": extra = "4"; break;
                    case "Algo Satisfecho": extra = "3"; break;
                    case "Muy Satisfecho": extra = "2"; break;
                    case "Completamente Satisfecho": extra = "1"; break;
                    case "No necesité una explicación.": extra = ""; break;
                    default: extra = "1"; break;
                }

                if (extra != "") extra = "<br /><img src='http://prospectos.carone.com.mx:8880/quest2/img/resp/face" + extra + ".png' width='50' height='50' alt='' border='' />";
                return extra;
            }
            else if (tipo == "3op")
            {
                switch (respuesta)
                {
                    case "Excede mis Expectativas": extra = "1"; break;
                    case "Cubre mis Expectativas": extra = "3"; break;
                    case "No cubre mis Expectativas": extra = "5"; break;
                    default: extra = ""; break;
                }

                if (extra != "") extra = "<br /><img src='http://prospectos.carone.com.mx:8880/quest2/img/resp/face" + extra + ".png' width='50' height='50' alt='' border='' />";
                return extra;
            }
            else if (tipo == "submenu1")
            {
                if (extra != "") extra = "<br /><img src='http://prospectos.carone.com.mx:8880/quest2/img/resp/b" + respuesta + ".png' width='50' height='50' alt='' border='' />";
                return extra;
            }
            else if ((tipo == "sc10") || (tipo == "sc5"))
            {
                if (extra != "") extra = "<br /><img src='http://prospectos.carone.com.mx:8880/quest2/img/resp/b" + respuesta + ".png' width='50' height='50' alt='' border='' />";
                return extra;
            }
            else if ((tipo == "3ele") || (tipo == "5stars") || (tipo == "4ele") || (tipo == "4op") || (tipo == "4b") || (tipo == "terminar") || (tipo == "comen"))
            {
                return extra;
            }
            else if ((tipo == "cb3") || (tipo == "tipopago") || (tipo == "entrega") || (tipo == "entrega2") || (tipo == "opinion") || (tipo == "tipopago"))
            {
                return extra;
            }
            else if (tipo == "10b")
            {
                if (respuesta != "") respuesta = "<br /><img src='http://prospectos.carone.com.mx:8880/quest2/img/resp/b" + respuesta + ".png' width='50' height='50' alt='' border='' />";
                return respuesta;
            }
            else if (tipo == "5o")
            {
                switch (respuesta)
                {
                    case "Excelente": extra = "1"; break;
                    case "Muy Bueno": extra = "2"; break;
                    case "Bueno": extra = "3"; break;
                    case "Regular": extra = "4"; break;
                    case "Malo": extra = "5"; break;
                    default: extra = ""; break;
                }

                if (extra != "") extra = "<br /><img src='http://prospectos.carone.com.mx:8880/quest2/img/resp/face" + extra + ".png' width='50' height='50' alt='' border='' />";
                return extra;
            }
            else if ((tipo == "sc10") || (tipo == "sc5"))
            {
                if (respuesta != "") respuesta = "<br /><img src='http://prospectos.carone.com.mx:8880/quest2/img/resp/n" + respuesta + ".png' width='50' height='50' alt='' border='' />";
                return respuesta;
            }
            else if (tipo == "5stars")
            {
                if (respuesta != "") respuesta = "<br /><img src='http://prospectos.carone.com.mx:8880/quest2/img/resp/estrella.png' width='50' height='50' alt='' border='' />";
                return respuesta;
            }
            else if (tipo == "5s")
            {
                switch (respuesta)
                {
                    case "uno": extra = "1"; break;
                    case "dos": extra = "2"; break;
                    case "tres": extra = "3"; break;
                    case "cuatro": extra = "4"; break;
                    case "cinco": extra = "5"; break;
                    default: extra = "5"; break;
                }

                if (extra != "") extra = "<br /><img src='http://prospectos.carone.com.mx:8880/quest2/img/resp/s" + extra + ".png' width='50' height='50' alt='' border='' />";
                return extra;
            }
            else if (tipo == "y/n")
            {
                if (respuesta == "Si") return "<br /><img src='http://prospectos.carone.com.mx:8880/quest2/img/resp/face6.png' width='50' height='50' alt='' border='' />";
                else if (respuesta == "No") return "<br /><img src='http://prospectos.carone.com.mx:8880/quest2/img/resp/face7.png' width='50' height='50' alt='' border='' />";
                else return "";
            }
            else if (tipo == "tcontacto")
            {
                if (respuesta == "Email") return "<br /><img src='http://prospectos.carone.com.mx:8880/quest2/img/resp/email.png' width='50' height='50' alt='' border='' />";
                else if (respuesta == "Telefono") return "<br /><img src='http://prospectos.carone.com.mx:8880/quest2/img/resp/telefono.png' width='50' height='50' alt='' border='' />";
                else return "";
            }
            else if (tipo == "y/n/na")
            {
                if (respuesta == "Si") return "<br /><img src='http://prospectos.carone.com.mx:8880/quest2/img/resp/face6.png' width='50' height='50' alt='' border='' />";
                else if (respuesta == "No") return "<br /><img src='http://prospectos.carone.com.mx:8880/quest2/img/resp/face7.png' width='50' height='50' alt='' border='' />";
                else if (respuesta == "No Aplica") return "<br /><img src='http://prospectos.carone.com.mx:8880/quest2/img/resp/face8.png' width='50' height='50' alt='' border='' />";
                else return "";
            }

            return "";
        }

        public bool fuentes(String marca, String agencia, String fecha_ini, String fecha_fin)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                //if (obj.show_sql("select A.id,A.marca,A.agencia,A.usuario as [clave usuario tablet],A.nombre as [nombre prospecto],A.telefono,A.email as [Email prospecto],C.clave as [clave vendedor],A.vendedor,C.email as [email vendedor],B.fuente,A.fecha,A.hora,A.acuenta,A.modelo from Tfuentes as A left join lasfuentes as B on A.fuente=B.clave left join Tvendedor as C on A.vendedor=C.nombre  where CONVERT(SmallDateTime, A.fecha, 103) between CONVERT(SmallDateTime, '" + fecha_ini + "', 103) and CONVERT(SmallDateTime, '" + fecha_fin + "', 103) and A.marca='" + marca + "' and A.agencia='" + agencia + "' order by A.id"))
                if (obj.show_sql("select A.id,A.marca,A.agencia,A.usuario as [clave usuario tablet],A.nombre as [nombre prospecto],A.telefono,A.email as [Email prospecto],A.clavevend as [clave vendedor],A.vendedor,A.emailvend as [email vendedor],B.fuente,A.fecha,A.hora,A.acuenta,A.modelo from Tfuentes as A left join lasfuentes as B on A.fuente=B.clave where CONVERT(SmallDateTime, A.fecha, 103) between CONVERT(SmallDateTime, '" + fecha_ini + "', 103) and CONVERT(SmallDateTime, '" + fecha_fin + "', 103) and A.marca='" + marca + "' and A.agencia='" + agencia + "' order by A.id"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.dt.Dispose();
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool elregistro(String id)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                String folio, tablin = "";

                prefijo = char.Parse(id.Substring(0, 1).ToUpper());
                folio = id.Substring(1);

                if (char.IsLetter(prefijo))
                {

                    if (prefijo == 'N') tablin = "tfuentes";
                    else if (prefijo == 'U') tablin = "tfuentes3";
                    else return false;

                    if (obj.show_sql("select * from " + tablin + " where id=" + folio))
                    {
                        if (obj.dt.Rows.Count < 1)
                        {
                            error = "Sin Datos";
                            obj.dt.Dispose();
                            obj.dt = null;
                            obj = null;
                            return false;
                        }
                        else
                        {
                            dt = obj.dt.Copy();
                            obj.dt.Dispose();
                            //buscar datos de pedido (si la hay)
                            if (obj.show_sql("select * from Tpedidoglobal where prefijo='" + prefijo + "' and idquest=" + folio))
                            {
                                if (obj.dt.Rows.Count > 0)
                                {
                                    dt.Rows[0][4] = obj.dt.Rows[0][3];
                                    dt.Rows[0][5] = obj.dt.Rows[0][4];
                                    dt.Rows[0][6] = obj.dt.Rows[0][5];
                                    obj.dt.Dispose();
                                }
                            }

                            obj.dt = null;
                            obj = null;
                            return true;
                        }
                    }
                    else
                    {
                        error = obj.error;
                        obj.dt.Dispose();
                        obj.error = null;
                        obj = null;
                        return false;
                    }
                }
                else return false;

            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool elregistro2(String id)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from tfuentes3 where id=" + id))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.dt.Dispose();
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        private Boolean get_dato(String cad)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql(cad))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        this.dt = null;
                        this.dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool ged_vend_mod(String metodo, String marca, String agencia)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                String tabla = "";
                if (metodo == "vendedores") tabla = "Tvendedor";
                else if (metodo == "modelos") tabla = "Tlosmodelos";
                if (obj.show_sql("select * from " + tabla + " with (nolock) where marc='" + marca + "' and agen='" + agencia + "'"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.dt.Dispose();
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool ged_vend_mod2(String marca, String agencia)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (marca == "MERCEDES BENZ")
                {
                    if (obj.show_sql("select * from mercedes_vend with (nolock) where agen='" + agencia + "'"))
                    {
                        if (obj.dt.Rows.Count < 1)
                        {
                            error = "Sin Datos";
                            obj.dt.Dispose();
                            obj.dt = null;
                            obj = null;
                            return false;
                        }
                        else
                        {
                            dt = obj.dt.Copy();
                            obj.dt.Dispose();
                            obj.dt = null;
                            obj = null;
                            return true;
                        }
                    }
                    else
                    {
                        error = obj.error;
                        obj.error = null;
                        obj = null;
                        return false;
                    }
                }
                else
                {
                    if (obj.conexion5(marca, agencia))
                    {
                        if (marca == "NISSAN")
                        {
                            if((agencia != "SAN JERONIMO") && (agencia != "SAN JERONIMO LAREDO") && (agencia != "LAS AGUILAS") && (agencia != "TLALPAN") && (agencia != "TLALPAN LAREDO") && (agencia != "LA JOYA") && (agencia != "LA JOYA LAREDO") && (agencia != "LA JOYA CROSSING"))
                            {
                                lacadena = obj.cadena;
                                obj = null;
                                return true;
                            }
                            else
                            {
                                /////////////////////////////////
                                sistema_global = obj.sistema_global;
                                if (obj.dt.Rows.Count < 1)
                                {
                                    error = "Vacio";
                                    obj.dt.Dispose();
                                    obj.dt = null;
                                    obj = null;
                                    return false;
                                }
                                else
                                {
                                    dt = obj.dt.Copy();
                                    obj.dt.Dispose();
                                    obj.dt = null;
                                    obj = null;
                                    return true;
                                }////codigo repetido arreglar despues
                            }
                        }                        
                        else
                        {
                            sistema_global = obj.sistema_global;
                            if (obj.dt.Rows.Count < 1)
                            {
                                error = "Vacio";
                                obj.dt.Dispose();
                                obj.dt = null;
                                obj = null;
                                return false;
                            }
                            else
                            {
                                dt = obj.dt.Copy();
                                obj.dt.Dispose();
                                obj.dt = null;
                                obj = null;
                                return true;
                            }
                        }
                    }
                    else
                    {
                        error = obj.error;
                        obj.error = null;
                        obj = null;
                        return false;
                    }
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool marcas_modelos(String marca)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Tmodelos2 with (nolock) where marca='" + marca + "'"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        private String adecuar(int valor)
        {
            if (valor.ToString().Length < 2) return "0" + valor.ToString();
            else return valor.ToString();
        }

        public bool datos_login(String log, String pas)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Tloginalarmas with (nolock) where login='" + log + "' and pass='" + pas + "'"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool datos_login2(String log, String pas)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Tlogin_rsalert with (nolock) where login='" + log + "' and pass='" + pas + "'"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool datos_alerta(String tipoenc, String agencias, String ids_enc)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                String sql = "", tipoencuesta, idsencuestas, ahora, mes_atras;
                String[] pedazos1, pedazos2;
                DateTime atras_30, hoy;
                int i;

                if (tipoenc.Trim() == "todas") tipoencuesta = "";
                else tipoencuesta = " and tipoenc='" + tipoenc.Trim() + "'";

                if (ids_enc.Trim() == "") idsencuestas = "";
                else idsencuestas = " and idenc not in (" + ids_enc + ")";

                hoy = DateTime.Now;
                atras_30 = DateTime.Now.AddDays(-2);
                ahora = hoy.ToString("dd/MM/yyyy");
                mes_atras = atras_30.ToString("dd/MM/yyyy");

                pedazos1 = Regex.Split(agencias, ",");

                for (i = 0; i < pedazos1.Length; i++)
                {
                    pedazos2 = Regex.Split(pedazos1[i], "-");
                    sql += "(select * from Talarmas where marca='" + pedazos2[0] + "' and agencia='" + pedazos2[1] + "' and CONVERT(SmallDateTime, fecha, 103) between CONVERT(SmallDateTime, '" + mes_atras + "', 103) and CONVERT(SmallDateTime, '" + ahora + "', 103)" + tipoencuesta + idsencuestas + ") union ";
                }

                sql = sql.Substring(0, (sql.Length - 7));
                sql += " order by marca,agencia,tipoenc,id";

                if (obj.show_sql(sql))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool datos_alerta3(String agencias)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                String sql = "", ahora, mes_atras;
                String[] pedazos1, pedazos2;
                DateTime atras_30, hoy;
                int i;


                hoy = DateTime.Now;
                atras_30 = DateTime.Now.AddDays(-2);
                ahora = hoy.ToString("dd/MM/yyyy");
                mes_atras = atras_30.ToString("dd/MM/yyyy");

                pedazos1 = Regex.Split(agencias, ",");

                for (i = 0; i < pedazos1.Length; i++)
                {
                    pedazos2 = Regex.Split(pedazos1[i], "-");
                    //sql += "(select * from rs_status where status='Nuevo Lead' and marca='" + pedazos2[0] + "' and agencia='" + pedazos2[1] + "' and CONVERT(SmallDateTime, fecha2, 103) between CONVERT(SmallDateTime, '" + mes_atras + "', 103) and CONVERT(SmallDateTime, '" + ahora + "', 103)) union ";
                    sql += "(select * from rs_status where status='Nuevo Lead' and marca='" + pedazos2[0] + "' and agencia='" + pedazos2[1] + "' and (ss!='' or sg!='' or sd!='') and CONVERT(SmallDateTime, fecha2, 103) between CONVERT(SmallDateTime, '" + mes_atras + "', 103) and CONVERT(SmallDateTime, '" + ahora + "', 103)) union ";
                }


                sql = sql.Substring(0, (sql.Length - 7));
                sql += " order by marca,agencia,tiempo,id";

                if (obj.show_sql(sql))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool datos_alerta2(String ids_enc)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                String sql = "", idsencuestas, ahora, mes_atras;
                DateTime atras_30, hoy;
                int i;

                if (ids_enc.Trim() == "") idsencuestas = "";
                else idsencuestas = " and idenc not in (" + ids_enc + ")";

                hoy = DateTime.Now;
                atras_30 = DateTime.Now.AddDays(-2);
                ahora = hoy.ToString("dd/MM/yyyy");
                mes_atras = atras_30.ToString("dd/MM/yyyy");

                sql = "select * from Talarmas where CONVERT(SmallDateTime, fecha, 103) between CONVERT(SmallDateTime, '" + mes_atras + "', 103) and CONVERT(SmallDateTime, '" + ahora + "', 103)" + idsencuestas + " order by marca,agencia,tipoenc,id";


                if (obj.show_sql(sql))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool datos_alerta4()
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                String sql = "", ahora, mes_atras;
                DateTime atras_30, hoy;
                int i;

                hoy = DateTime.Now;
                atras_30 = DateTime.Now.AddDays(-2);
                ahora = hoy.ToString("dd/MM/yyyy");
                mes_atras = atras_30.ToString("dd/MM/yyyy");

                //sql = "select * from rs_status where status='Nuevo Lead' and CONVERT(SmallDateTime, fecha2, 103) between CONVERT(SmallDateTime, '" + mes_atras + "', 103) and CONVERT(SmallDateTime, '" + ahora + "', 103) order by marca,agencia,tiempo,id";
                sql = "select * from rs_status where status='Nuevo Lead' and CONVERT(SmallDateTime, fecha2, 103) between CONVERT(SmallDateTime, '" + mes_atras + "', 103) and CONVERT(SmallDateTime, '" + ahora + "', 103) order by marca,agencia,tiempo,id";

                if (obj.show_sql(sql))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool datos_alerta5()
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                String sql = "", ahora, mes_atras;
                DateTime atras_30, hoy;
                int i;

                hoy = DateTime.Now;
                atras_30 = DateTime.Now.AddDays(-2);
                ahora = hoy.ToString("dd/MM/yyyy");
                mes_atras = atras_30.ToString("dd/MM/yyyy");

                sql = "select * from rs_status where status='Nuevo Lead' and CONVERT(SmallDateTime, fecha2, 103) between CONVERT(SmallDateTime, '" + mes_atras + "', 103) and CONVERT(SmallDateTime, '" + ahora + "', 103) and sd!='' order by marca,agencia,tiempo,id";

                if (obj.show_sql(sql))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }


        public bool datos_prospectos(String agencias)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                DateTime hoy = DateTime.Now;

                if ((agencias == "CORPORATIVO") || (agencias == "DIRECCION"))
                {
                    if (obj.show_sql("select * from Tfuentes with (nolock) where fecha='" + hoy.ToString("dd/MM/yyyy") + "' order by marca,agencia,id"))
                    {
                        if (obj.dt.Rows.Count < 1)
                        {
                            error = "Sin Datos";
                            obj.dt.Dispose();
                            obj.dt = null;
                            obj = null;
                            return false;
                        }
                        else
                        {
                            dt = obj.dt.Copy();
                            obj.dt.Dispose();
                            obj.dt = null;
                            obj = null;
                            return true;
                        }
                    }
                    else
                    {
                        error = obj.error;
                        obj.error = null;
                        obj = null;
                        return false;
                    }
                }
                else
                {
                    String sql = "";
                    String[] pedazos1, pedazos2;
                    int i;

                    pedazos1 = Regex.Split(agencias, ",");

                    for (i = 0; i < pedazos1.Length; i++)
                    {
                        pedazos2 = Regex.Split(pedazos1[i], "-");
                        sql += "(select * from Tfuentes where marca='" + pedazos2[0] + "' and agencia='" + pedazos2[1] + "' and fecha='" + hoy.ToString("dd/MM/yyyy") + "') union ";
                    }

                    sql = sql.Substring(0, (sql.Length - 7));
                    sql += " order by marca,agencia,id";

                    if (obj.show_sql(sql))
                    {
                        if (obj.dt.Rows.Count < 1)
                        {
                            error = "Sin Datos";
                            obj.dt.Dispose();
                            obj.dt = null;
                            obj = null;
                            return false;
                        }
                        else
                        {
                            dt = obj.dt.Copy();
                            obj.dt.Dispose();
                            obj.dt = null;
                            obj = null;
                            return true;
                        }
                    }
                    else
                    {
                        error = obj.error;
                        obj.error = null;
                        obj = null;
                        return false;
                    }
                }
            }
            catch (Exception er)
            {
                this.error = "Error: " + er.ToString();
                obj = null;
                return false;
            }
        }

        public bool insertar_chat(String msg)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                string[] pedazos = Regex.Split(msg, "\\%\\&");
                DateTime hoy;
                hoy = DateTime.Now;

                if (pedazos.Length == 9)
                {
                    if (obj.data("insert", "", "'" + pedazos[0] + "','" + pedazos[1] + "','" + pedazos[2] + "'," + int.Parse(pedazos[3]) + "," + int.Parse(pedazos[4]) + "," + int.Parse(pedazos[5]) + "," + int.Parse(pedazos[6]) + ",'" + pedazos[7] + "','" + pedazos[8] + "','" + hoy.ToString("dd/MM/yyyy") + "','" + hoy.ToString("HH:mm") + "'", "Tchatalarmas", ""))
                    {
                        cad_JSON = "Dato Archivado";
                        return true;
                    }
                    else
                    {
                        this.error = "Error: " + obj.error;
                        return false;
                    }
                }
                else
                {
                    this.error = "Error: no cumple tamanio del array";
                    return false;
                }

            }
            catch (Exception er)
            {
                this.error = "Error: " + er.ToString();
                obj = null;
                return false;
            }
        }

        public bool insertar_chat2(String msg)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                string[] pedazos = Regex.Split(msg, "\\$\\#");
                DateTime hoy;
                hoy = DateTime.Now;

                if (pedazos.Length == 9)
                {
                    if (obj.data("insert", "", "'" + pedazos[0] + "','" + pedazos[1] + "','" + pedazos[2] + "'," + int.Parse(pedazos[3]) + "," + int.Parse(pedazos[4]) + "," + int.Parse(pedazos[5]) + "," + int.Parse(pedazos[6]) + ",'" + pedazos[7] + "','" + pedazos[8] + "','" + hoy.ToString("dd/MM/yyyy") + "','" + hoy.ToString("HH:mm") + "'", "Tchatalarmas", ""))
                    {
                        cad_JSON = "Dato Archivado";
                        return true;
                    }
                    else
                    {
                        this.error = "Error: " + obj.error;
                        return false;
                    }
                }
                else
                {
                    this.error = "Error: no cumple tamanio del array";
                    return false;
                }

            }
            catch (Exception er)
            {
                this.error = "Error: " + er.ToString();
                obj = null;
                return false;
            }
        }

        public bool seleccionar_chat(String id_Talarmas)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select id_user,nombres,msg,fecha,hora from Tchatalarmas with (nolock) where id_talarmas=" + id_Talarmas + " order by id"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool checar_baneo(String id_user)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select baneado from Tloginalarmas with (nolock) where id='" + id_user + "'"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool enviar_correo(String remitente, String destino, String asunto, String msg)
        {
            emailsender obj = new emailsender();

            try
            {
                if (obj.sender("alarma@carone.com.mx", destino, "", "caronesite@gmail.com", asunto, "", msg))
                {
                    return true;
                }
                else
                {
                    this.error = "Error: " + obj.error_mail;
                    return false;
                }
            }
            catch (Exception er)
            {
                this.error = "Error: " + er.ToString();
                obj = null;
                return false;
            }
        }

        public bool enviar_correo3(String remitente, String destino, String asunto, String msg, String usuario, String telefono, String id_lead)
        {
            emailsender obj = new emailsender();

            try
            {
                String elfolio, puntosfinales;
                String[] pedazos1, pedazos2;
                int j;
                StringBuilder builder3 = new StringBuilder();
                SMS_referencia.servicioSoapClient webserv = new SMS_referencia.servicioSoapClient();
                puntosfinales = webserv.rs_prospecto(id_lead);
                pedazos1 = Regex.Split(puntosfinales, "\\%\\&");
                builder3.Clear();
                builder3.Append("<br><br><center>");
                builder3.Append("<table cellpadding='5' cellspacing='0' border='0'>");
                builder3.Append("<tr><td colspan='2' style='font-size:15px;background-color:#0C7FA8;color:#FFFFFF'>DATOS DEL LEAD:</td></tr>");

                for (j = 0; j < pedazos1.Length; j++)
                {
                    pedazos2 = Regex.Split(pedazos1[j], "\\#\\+");
                    if (j == 0) elfolio = pedazos2[1];
                    builder3.Append("<tr><td bgcolor='#145114' align='right' style='font-family: Arial; font-weight: bold; color: #FFFFFF' width='300'>" + pedazos2[0] + "</td>");
                    if (pedazos2.Length > 1) builder3.Append("<td bgcolor='#00c921' align='left' style='font-family: Arial; color: #dceddf'  width='300'>" + pedazos2[1] + "</td></tr>");
                    else builder3.Append("<td bgcolor='#00c921' align='left' style='font-family: Arial; color: #dceddf'  width='300'></td></tr>");
                }

                builder3.Append("</table><br>");

                if (obj.sender("alarma@carone.com.mx", destino, "", "caronesite@gmail.com", asunto, "", "Usuario: " + usuario + "<br/>" + msg + "<br/>" + builder3.ToString()))
                {
                    //return true;
                }
                else
                {
                    //this.error = "Error: " + obj.error_mail;
                    //return false;
                }

                if (existe_archivo2(id_lead + ".png"))
                {//si existe
                    SMS_referencia.servicioSoapClient servicioweb2 = new SMS_referencia.servicioSoapClient();
                    String sql = "select * from whatsapplist with (nolock) where telefono='" + telefono + "'";
                    if (get_dato(sql))
                    {
                        servicioweb2.whatsapp_msg("+14155238886", "+521" + telefono, "usuario: " + usuario + " " + msg, "http://prospectos.carone.com.mx:8880/ws2/generados/" + id_lead + ".png");
                        System.Threading.Thread.Sleep(2000);
                    }
                }
                else
                {//no existe                    
                    WebsitesScreenshot.WebsitesScreenshot _Obj = new WebsitesScreenshot.WebsitesScreenshot();
                    WebsitesScreenshot.WebsitesScreenshot.Result _Result = _Obj.CaptureHTML(builder3.ToString());
                    if (_Result == WebsitesScreenshot.WebsitesScreenshot.Result.Captured)
                    {
                        _Obj.ImageFormat = WebsitesScreenshot.WebsitesScreenshot.ImageFormats.PNG;
                        //_Obj.ImageHeight = 800;
                        //_Obj.ImageWidth = 400;
                        //_Obj.PreserveAspectRatio = true;

                        //_Obj.BrowserHeight = 800;
                        //_Obj.BrowserWidth=400;
                        _Obj.SaveImage(System.Web.HttpContext.Current.Server.MapPath("~/generados/" + id_lead + ".png"));
                    }
                    _Obj.Dispose();

                    SMS_referencia.servicioSoapClient servicioweb2 = new SMS_referencia.servicioSoapClient();
                    String sql = "select * from whatsapplist with (nolock) where telefono='" + telefono + "'";
                    if (get_dato(sql))
                    {
                        servicioweb2.whatsapp_msg("+14155238886", "+521" + telefono, "usuario: " + usuario + " " + msg, "http://prospectos.carone.com.mx:8880/ws2/generados/" + id_lead + ".png");
                        System.Threading.Thread.Sleep(2000);
                    }

                }

                return true;

            }
            catch (Exception er)
            {
                this.error = "Error: " + er.ToString();
                obj = null;
                return false;
            }
        }

        public bool registrar_llamada(String iduser, String nombre, String agencia)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                DateTime hoy;
                hoy = DateTime.Now;

                if (obj.data("insert", "", "'" + iduser + "','" + nombre + "','" + agencia + "','" + hoy.ToString("dd/MM/yyyy") + "','" + hoy.ToString("HH:mm") + "'", "Tregitro_llamadas", ""))
                {
                    cad_JSON = "Dato Archivado";
                    return true;
                }
                else
                {
                    this.error = "Error: " + obj.error;
                    return false;
                }
            }
            catch (Exception er)
            {
                this.error = "Error: " + er.ToString();
                obj = null;
                return false;
            }
        }

        public bool registrar_seguimiento(String id_talarmas, String idenc, String invord, String conclusion)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from tconclusion with (nolock) where id_talarmas='" + id_talarmas + "'"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {   //nuevo insert
                        if (obj.data("insert", "", "'" + id_talarmas + "','" + idenc + "','" + invord + "','" + conclusion + "'", "tconclusion", ""))
                        {
                            cad_JSON = "Dato Archivado";
                            return true;
                        }
                        else
                        {
                            this.error = "Error: " + obj.error;
                            return false;
                        }
                    }
                    else
                    {   //  repetido update
                        if (obj.data("update", "", "conclusion='" + conclusion + "'", "tconclusion", "id_talarmas='" + id_talarmas + "'"))
                        {
                            cad_JSON = "Dato Archivado";
                            return true;
                        }
                        else
                        {
                            this.error = "Error: " + obj.error;
                            return false;
                        }
                    }
                }
                else
                {
                    if (obj.error == "Sin Datos")
                    {
                        //nuevo insert
                        if (obj.data("insert", "", "'" + id_talarmas + "','" + idenc + "','" + invord + "','" + conclusion + "'", "tconclusion", ""))
                        {
                            cad_JSON = "Dato Archivado";
                            return true;
                        }
                        else
                        {
                            this.error = "Error: " + obj.error;
                            return false;
                        }
                    }
                    else
                    {
                        error = obj.error;
                        obj.error = null;
                        obj = null;
                        return false;
                    }
                }
            }
            catch (Exception er)
            {
                this.error = "Error: " + er.ToString();
                obj = null;
                return false;
            }
        }

        public bool leer_conclusion(String id_talarmas)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select conclusion from tconclusion with (nolock) where id_talarmas='" + id_talarmas + "'"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool registrar_token(String login, String password, String tokendevice)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                // update
                if (obj.data("update", "", "tokendevice='" + tokendevice + "'", "Tloginalarmas", "login='" + login + "' and pass='" + password + "'"))
                {
                    cad_JSON = "Dato Archivado";
                    return true;
                }
                else
                {
                    this.error = "Error: " + obj.error;
                    return false;
                }
            }
            catch (Exception er)
            {
                this.error = "Error: " + er.ToString();
                obj = null;
                return false;
            }
        }

        public bool registrar_token2(String login, String password, String tokendevice)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                // update
                if (obj.data("update", "", "tokendevice='" + tokendevice + "'", "Tlogin_rsalert", "login='" + login + "' and pass='" + password + "'"))
                {
                    cad_JSON = "Dato Archivado";
                    return true;
                }
                else
                {
                    this.error = "Error: " + obj.error;
                    return false;
                }
            }
            catch (Exception er)
            {
                this.error = "Error: " + er.ToString();
                obj = null;
                return false;
            }
        }

        public bool registrar_token3(String login, String password, String tokendevice)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                // update
                if (obj.data("update", "", "tokendevice='" + tokendevice + "'", "Tlogin_tomadeautos", "login='" + login + "' and pass='" + password + "'"))
                {
                    cad_JSON = "Dato Archivado";
                    return true;
                }
                else
                {
                    this.error = "Error: " + obj.error;
                    return false;
                }
            }
            catch (Exception er)
            {
                this.error = "Error: " + er.ToString();
                obj = null;
                return false;
            }
        }

        public bool registrar_token4(String login, String password, String tokendevice)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                // update
                if (obj.data("update", "", "tokendevice='" + tokendevice + "'", "Tparticipantes", "login='" + login + "' and pass='" + password + "'"))
                {
                    cad_JSON = "Dato Archivado";
                    return true;
                }
                else
                {
                    this.error = "Error: " + obj.error;
                    return false;
                }
            }
            catch (Exception er)
            {
                this.error = "Error: " + er.ToString();
                obj = null;
                return false;
            }
        }

        public bool enviar_campana(String msg, String id_talarmas, String id_enc, String marca, String agencia, String tipoenc)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                String sql = "", loscorreos = "", lostelefonos = "";
                String[] datos_client, enc_datcli;
                StringBuilder builder = new StringBuilder();
                int i;

                sql = "select tbl_cliente,tbl_encuesta from talarmas with (nolock) where id=" + id_talarmas;
                if (get_dato(sql))
                {

                    builder.Append("<br><br><br>CARLOS ROBLES:<br><br>" + msg);

                    if (marca == "MERCEDES BENZ")
                    {
                        if (dt.Rows.Count == 1)
                        {
                            String tabla_encuesta = "";

                            datos_client = Regex.Split(dt.Rows[0][1].ToString(), "%&");
                            builder.Append("<br><br><br>ENCUESTA ID: " + id_enc + "<br>");
                            builder.Append("<table cellpadding='5' cellspacing='0' border='0'>");

                            for (i = 0; i < datos_client.Length; i++)
                            {
                                enc_datcli = Regex.Split(datos_client[i].ToString(), "+");

                                if (enc_datcli.Length > 1)
                                {
                                    builder.Append("<tr><td bgcolor='" + enc_datcli[0] + "' align='left' style='font-family: Arial; font-weight: bold; color: #FFFFFF' width='800'>" + enc_datcli[1] + ":</td>");
                                    builder.Append("<td bgcolor='#669999' align='left' style='font-family: Arial; color: #CCCCFF'  width='300'>" + enc_datcli[2] + extra(enc_datcli[3].ToString(), enc_datcli[2].ToString()) + "</td></tr>");
                                    builder.Append("<tr colspan='2' bgcolor='#555555' height='1'></tr>");
                                }
                                else
                                {
                                    builder.Append("<tr><td bgcolor='" + enc_datcli[0] + "' align='left' style='font-family: Arial; font-weight: bold; color: #FFFFFF' width='800'>" + enc_datcli[1] + ":</td>");
                                    builder.Append("<td bgcolor='#669999' align='left' style='font-family: Arial; color: #CCCCFF'  width='300'></td></tr>");
                                    builder.Append("<tr colspan='2' bgcolor='#555555' height='1'></tr>");
                                }
                            }

                            builder.Append("</table></center><br><br><br>");

                            sql = "select * from Tloginalarmas where (tipoenc='" + tipoenc + "' or tipoenc='todas') and agencias like '%" + marca + "-" + agencia + "%' or agencias='CORPORATIVO'";
                            if (get_dato(sql))
                            {
                                for (i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (dt.Rows[i][5].ToString().Trim() != "")
                                    {
                                        loscorreos += dt.Rows[i][5].ToString().Trim() + ",";
                                    }

                                    if (dt.Rows[i][6].ToString().Trim() != "")
                                    {
                                        lostelefonos += dt.Rows[i][6].ToString().Trim() + ",";
                                    }
                                }
                                loscorreos = loscorreos.Substring(0, (loscorreos.Length - 1));
                                lostelefonos = lostelefonos.Substring(0, (lostelefonos.Length - 1));
                                emailsender obj2 = new emailsender();
                                obj2.sender("alarma@carone.com.mx", loscorreos, "", "caronesite@gmail.com", "CARLOS ROBLES", "", builder.ToString());
                                //obj2.sender("alarma@carone.com.mx", "dukard@hotmail.com", "", "caronesite@gmail.com", "CARLOS ROBLES", "", builder.ToString());
                            }
                        }

                        ///end mercedes
                    }
                    else
                    {
                        if (dt.Rows.Count == 1)
                        {
                            String marcados, tabla_cliente = "", tabla_encuesta = "", no_invord = "";

                            datos_client = Regex.Split(dt.Rows[0][0].ToString(), "%&");
                            builder.Append("<br><br><center>");
                            builder.Append("<table cellpadding='5' cellspacing='0' border='0'>");
                            builder.Append("<tr><td colspan='2' style='font-size:15px;background-color:#0C7FA8;color:#FFFFFF'>DATOS DEL CLIENTE:</td></tr>");

                            for (i = 0; i < datos_client.Length; i++)
                            {
                                enc_datcli = datos_client[i].ToString().Split('+');

                                if (enc_datcli.Length > 1)
                                {
                                    builder.Append("<tr><td bgcolor='#990099' align='right' style='font-family: Arial; font-weight: bold; color: #FFFFFF' width='300'>" + enc_datcli[0] + ":</td>");
                                    builder.Append("<td bgcolor='#669999' align='left' style='font-family: Arial; color: #CCCCFF'  width='300'>" + enc_datcli[1] + "</td></tr>");
                                    tabla_cliente += enc_datcli[0] + "+" + datos_client[1] + "%&";
                                }
                                else
                                {
                                    builder.Append("<tr><td bgcolor='#990099' align='right' style='font-family: Arial; font-weight: bold; color: #FFFFFF' width='300'>" + enc_datcli[0] + ":</td>");
                                    builder.Append("<td bgcolor='#669999' align='left' style='font-family: Arial; color: #CCCCFF'  width='300'></td></tr>");
                                    tabla_cliente += enc_datcli[0] + "+%&";
                                }
                            }

                            datos_client = Regex.Split(dt.Rows[0][1].ToString(), "%&");
                            builder.Append("</table><br><br><br>ENCUESTA ID: " + id_enc + "<br>");
                            builder.Append("<table cellpadding='5' cellspacing='0' border='0'>");

                            for (i = 0; i < datos_client.Length; i++)
                            {
                                enc_datcli = datos_client[i].ToString().Split('+');

                                if (enc_datcli.Length > 1)
                                {
                                    builder.Append("<tr><td bgcolor='" + enc_datcli[0] + "' align='left' style='font-family: Arial; font-weight: bold; color: #FFFFFF' width='800'>" + enc_datcli[1] + ":</td>");
                                    builder.Append("<td bgcolor='#669999' align='left' style='font-family: Arial; color: #CCCCFF'  width='300'>" + enc_datcli[2] + extra(enc_datcli[3].ToString(), enc_datcli[2].ToString()) + "</td></tr>");
                                    builder.Append("<tr colspan='2' bgcolor='#555555' height='1'></tr>");
                                }
                                else
                                {
                                    /*builder.Append("<tr><td bgcolor='" + enc_datcli[0] + "' align='left' style='font-family: Arial; font-weight: bold; color: #FFFFFF' width='800'>" + enc_datcli[1] + ":</td>");
                                    builder.Append("<td bgcolor='#669999' align='left' style='font-family: Arial; color: #CCCCFF'  width='300'></td></tr>");
                                    builder.Append("<tr colspan='2' bgcolor='#555555' height='1'></tr>");*/
                                }
                            }

                            builder.Append("</table></center><br><br><br>");

                            sql = "select * from Tloginalarmas where (tipoenc='" + tipoenc + "' or tipoenc='todas') and agencias like '%" + marca + "-" + agencia + "%' or agencias='CORPORATIVO'";
                            if (get_dato(sql))
                            {
                                for (i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (dt.Rows[i][5].ToString().Trim() != "")
                                    {
                                        loscorreos += dt.Rows[i][5].ToString().Trim() + ",";
                                    }

                                    if (dt.Rows[i][6].ToString().Trim() != "")
                                    {
                                        lostelefonos += dt.Rows[i][6].ToString().Trim() + ",";
                                    }
                                }
                                loscorreos = loscorreos.Substring(0, (loscorreos.Length - 1));
                                lostelefonos = lostelefonos.Substring(0, (lostelefonos.Length - 1));
                                emailsender obj2 = new emailsender();
                                obj2.sender("alarma@carone.com.mx", loscorreos, "", "caronesite@gmail.com", "CARLOS ROBLES", "", builder.ToString());
                                //obj2.sender("alarma@carone.com.mx", "dukard@hotmail.com", "", "caronesite@gmail.com", "CARLOS ROBLES", "", builder.ToString());
                            }

                        }



                    } //count ==1
                } //end sql3           


                SMS_referencia.servicioSoapClient cliente = new SMS_referencia.servicioSoapClient();

                if (msg.Length > 145) cliente.SMS_function("COM4", lostelefonos, msg.Substring(0, 145));
                else cliente.SMS_function("COM4", lostelefonos, "CARLOS ROBLES:\n" + msg);


                return true;



            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }


        public bool las_agencias()
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select marca,lugaragen from tagenandroid with (nolock) where marca not IN ('DODGE','JEEP','RAM') and marca not in ('NISSAN','SMART') order by marca,lugaragen"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.dt.Dispose();
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool los_modelos()
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Tmodelos2 with (nolock) order by marca,modelo"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.dt.Dispose();
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool insert_prospectos_redes(String marca, String agencia, String nombre, String telefono, String email, String acuenta, String modelo, String marca2, String agencia2, String tipoauto)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                String latabla, cadena;

                latabla = "Tfuentes_redes";

                //checo si es repetido de doble click
                cadena = "select * from " + latabla + " with (nolock) where nombre='" + nombre + "' and telefono='" + telefono + "' and email='" + email + "' and marca2='" + marca2 + "' and agencia2='" + agencia2 + "'";

                if (obj.show_sql(cadena))
                {
                    cad_JSON = "Error: " + "Dato Repetido";
                    return true;
                }
                else
                {
                    if (obj.error == "Sin Datos")
                    {
                        if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + nombre + "','" + telefono + "','" + email + "','" + acuenta + "','" + modelo + "','" + marca2 + "','" + agencia2 + "','" + tipoauto + "','',''", latabla, ""))
                        {
                            cad_JSON = "Dato Archivado";
                            return true;
                        }
                        else
                        {
                            this.error = "Error: " + obj.error;
                            return false;
                        }
                    }
                    else
                    {
                        this.error = "Error: " + obj.error;
                        return false;
                    }
                }
            }
            catch (Exception er)
            {
                this.error = "Error: " + er.ToString();
                obj = null;
                return false;
            }
        }

        public bool insert_ceo_encuestas(String marca, String agencia, String encuesta, String resultado, String fecha, String hora)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                String cadena;


                //checo si es repetido de doble click
                cadena = "select * from Tceo_encuestas with (nolock) where marca='" + marca + "' and agencia='" + agencia + "' and encuesta='" + encuesta + "' and fecha='" + fecha + "' and hora='" + hora + "'";

                if (obj.show_sql(cadena))
                {
                    cad_JSON = "Dato Repetido";
                    return true;
                }
                else
                {
                    if (obj.error == "Sin Datos")
                    {
                        if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + encuesta + "','" + resultado + "','" + fecha + "','" + hora + "'", "Tceo_encuestas", ""))
                        {
                            cad_JSON = "Dato Archivado";
                            return true;
                        }
                        else
                        {
                            this.error = "Error: " + obj.error;
                            return false;
                        }
                    }
                    else
                    {
                        this.error = "Error: " + obj.error;
                        return false;
                    }
                }
            }
            catch (Exception er)
            {
                this.error = "Error: " + er.ToString();
                obj = null;
                return false;
            }
        }

        public bool info_combo_sistemas(String marca, String agencia, String tipo, String fecha1, String fecha2)
        {
            wfunciones1 obj8 = new wfunciones1();

            if (obj8.conexion8(tipo, marca, agencia, fecha1, fecha2))
            {
                if (obj8.dt.Rows.Count < 1)
                {
                    obj8.dt.Dispose();
                    return false;
                }
                else
                {
                    dt = obj8.dt.Copy();
                    obj8.dt.Dispose();
                    return true;
                }
            }

            return false;
        }

        public bool info_combo_sistemas2(String marca, String agencia, String tipo, String fecha1, String fecha2)
        {
            wfunciones1 obj8 = new wfunciones1();

            int we3, ho3, jo3;
            String ips3 = "";

            if (agencia == "TODAS")
            {
                if (marca == "KIA") ips3 = "GONZALITOS,LINDA VISTA,REYNOSA,LAREDO";
                else if (marca == "CHRYSLER") ips3 = "CUMBRES,SANTA LUCIA,P.ABASTOS,LINARES";
                else if (marca == "FORD") ips3 = "VALLE,VASCONCELOS";
                else if (marca == "FIAT") ips3 = "CUMBRES";
                else if (marca == "MITSUBISHI") ips3 = "SANTA LUCIA";
                else if (marca == "CHEVROLET") ips3 = "TLALPAN,LAS BOMBAS,RUIZ CORTINES,NOGALAR,CONCORDIA,LAS TORRES,ALLENDE,UNIVERSIDAD";
            }

            string[] ags3 = ips3.Split(',');

            for (ho3 = 0; ho3 < ags3.Length; ho3++)
            {
                if (obj8.conexion8(tipo, marca, ags3[ho3], fecha1, fecha2))
                {
                    if (obj8.dt.Rows.Count < 1)
                    {
                        //
                    }
                    else
                    {
                        for (jo3 = 0; jo3 < obj8.dt.Rows.Count; jo3++)
                        {
                            invords3 += obj8.dt.Rows[jo3][0].ToString() + ",";
                        }
                    }
                }
            }

            if (invords3 != "") invords3 = invords3.Substring(0, (invords3.Length - 1));

            obj8.dt.Dispose();
            return true;
        }

        public void llena_tabla()
        {
            DataTable aux5;
            int jf, i;
            string[] datos_client;
            String ids, marca, agencia, tipoenc, idenc, invord2, fecha, asesor;

            //String sql = "select marca,agencia,tipoenc,id,invord2,fecha from tencuestas where id BETWEEN " + ini + " AND " + fin + " AND fecha like '%/2018' order by id";
            //String sql = "select marca,agencia,tipoenc,id,invord2,fecha from tencuestas where id BETWEEN " + ini + " AND " + fin + " AND fecha like '%/2018' order by id";
            wfunciones1 obj15 = new wfunciones1();

            if (obj15.mod_sql("insert into enc_vend (marca,agencia,tipoenc,idenc,invord,vendedor,fecha) (select marca,agencia,tipoenc,id,invord2,'' as vendedor,fecha from Tencuestas where id in (select id from Tencuestas where fecha like '%/2018' except select idenc from enc_vend))"))
            {
                String sql = "select * from enc_vend where vendedor='' order by id";
                if (get_dato(sql))
                {
                    aux5 = dt.Copy();

                    for (jf = 0; jf < aux5.Rows.Count; jf++)
                    {
                        datos_client = new string[0];
                        asesor = "";
                        cad_JSON = "";
                        ids = aux5.Rows[jf][0].ToString();
                        marca = aux5.Rows[jf][1].ToString();
                        agencia = aux5.Rows[jf][2].ToString();
                        tipoenc = aux5.Rows[jf][3].ToString();
                        idenc = aux5.Rows[jf][4].ToString();
                        invord2 = aux5.Rows[jf][5].ToString();
                        fecha = aux5.Rows[jf][7].ToString();
                        /*marca = aux5.Rows[jf][0].ToString();
                        agencia = aux5.Rows[jf][1].ToString();
                        tipoenc = aux5.Rows[jf][2].ToString();
                        idenc = aux5.Rows[jf][3].ToString();
                        invord2 = aux5.Rows[jf][4].ToString();
                        fecha = aux5.Rows[jf][5].ToString();*/

                        if (marca == "NISSAN")
                        {
                            obj15.data("update", "", "vendedor='Error'", "enc_vend", "id=" + ids);
                        }
                        else
                        {
                            if (datos_cliente(tipoenc, marca, agencia, invord2))
                            {
                                if (aux5.Rows[jf][0].ToString() == "NISSAN")
                                {
                                    cad_JSON = lanissan;
                                    cad_JSON = cad_JSON.Replace("\\", "").Replace("\"", "");
                                    datos_client = Regex.Split(cad_JSON, "%&");
                                }
                                else
                                {
                                    for (i = 0; i < (dt.Columns.Count - 1); i++)
                                    {
                                        cad_JSON += dt.Rows[0][i] + "%&";
                                    }

                                    cad_JSON += dt.Rows[0][i];
                                    dt.Dispose();
                                    cad_JSON = cad_JSON.Replace("\\", "").Replace("\"", "");
                                    datos_client = Regex.Split(cad_JSON, "%&");
                                }

                                Boolean multimarca = false, sis_global = false, autoline = false;

                                if (marca == "FORD") sis_global = true;
                                else if (marca == "MERCEDES BENZ") autoline = true;
                                else if (marca == "KIA") sis_global = true;
                                else if (marca == "NISSAN") sis_global = true;
                                else if (marca == "CHRYSLER") sis_global = true;
                                else if (marca == "FIAT") sis_global = true;
                                else if (marca == "MITSUBISHI") sis_global = true;
                                else if ((marca == "CHEVROLET") && (agencia == "TLALPAN")) sis_global = true;
                                else if ((marca == "CHEVROLET") && (agencia == "LAS BOMBAS")) sis_global = true;
                                else if ((marca == "CHEVROLET") && (agencia == "RUIZ CORTINES")) sis_global = true;
                                else if ((marca == "CHEVROLET") && (agencia == "NOGALAR")) sis_global = true;
                                else if ((marca == "CHEVROLET") && (agencia == "CONCORDIA")) sis_global = true;
                                else if ((marca == "CHEVROLET") && (agencia == "LAS TORRES")) sis_global = true;
                                else if ((marca == "CHEVROLET") && (agencia == "ALLENDE")) sis_global = true;
                                else if ((marca == "CHEVROLET") && (agencia == "UNIVERSIDAD")) sis_global = true;
                                else multimarca = true;

                                if (sis_global)
                                {
                                    if (tipoenc == "venta")
                                    {
                                        asesor = datos_client[14];
                                    }
                                    else
                                    {
                                        asesor = datos_client[16];
                                    }
                                }
                                else if (multimarca)
                                {
                                    if (tipoenc == "venta")
                                    {
                                        asesor = datos_client[20];
                                    }
                                    else
                                    {
                                        asesor = datos_client[15];
                                    }
                                }
                                else if (autoline)
                                {
                                    //if (tipoenc == "venta") sms_msg = "";
                                    //else sms_msg = "";
                                }

                                ////obj15.data("insert", "", "'" + marca + "','" + agencia + "','" + tipoenc + "','" + idenc + "','" + invord2 + "','" + asesor + "','" + fecha + "'", "enc_vend", "");
                                obj15.data("update", "", "vendedor='" + asesor + "'", "enc_vend", "id=" + ids);




                            }  //end clientes
                            else
                            {
                                // sin datos del cliente
                                ///obj15.data("insert", "", "'" + marca + "','" + agencia + "','" + tipoenc + "','" + idenc + "','" + invord2 + "','','" + fecha + "'", "enc_vend", "");
                                obj15.data("update", "", "vendedor='Error'", "enc_vend", "id=" + ids);
                            }
                        }

                    }    //  end for          
                }
            }


        }

        public bool archivar_imagen(String nombrearchivo, byte[] imagen)
        {
            try
            {
                MemoryStream ms = new MemoryStream(imagen);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                /////Bitmap img2 = new Bitmap(img);

                if (existe_archivo(nombrearchivo))
                {//si existe
                    File.Delete(System.Web.HttpContext.Current.Server.MapPath("~/ceo/" + nombrearchivo));
                    img.Save(System.Web.HttpContext.Current.Server.MapPath("~/ceo/" + nombrearchivo), System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else
                {//no existe                    
                    img.Save(System.Web.HttpContext.Current.Server.MapPath("~/ceo/" + nombrearchivo));
                }

                img.Dispose();
                ms.Dispose();
                return true;
            }
            catch (Exception er)
            {
                this.error = "Error2: " + er.ToString();
                return false;
            }
        }

                                                                             
        public bool archivar_datos(string idvigilante,string marc,string agen,string io,string depto,string repuve,string placa,string vin,string foliofactura,string nombrefoto, byte[] imagen)
        {
            try
            {
                wfunciones1 obj = new wfunciones1();
                MemoryStream ms = new MemoryStream(imagen);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                /////Bitmap img2 = new Bitmap(img);
                DateTime hoy = DateTime.Now;

                if (existe_archivo(nombrefoto)) { /*si existe*/   File.Delete(System.Web.HttpContext.Current.Server.MapPath("~/ceo/" + nombrefoto)); }
                img.Save(System.Web.HttpContext.Current.Server.MapPath("~/ceo/" + nombrefoto), System.Drawing.Imaging.ImageFormat.Jpeg);

                if (obj.data("insert", "", "'" + idvigilante + "','" + marc + "','" + agen + "','" + io + "','" + depto + "','" + repuve + "','" + placa + "','" + vin + "','" + foliofactura + "','" + nombrefoto + "','" + hoy.ToString("dd/MM/yyyy") + "','" + hoy.ToString("HH:mm") + "'", "Tioautos", ""))
                {
                    img.Dispose();
                    ms.Dispose();

                    if (obj.show_sql("select * from Tioautos where vin='" + vin + "' order by id desc"))
                    {
                        if (obj.dt.Rows.Count < 1)
                        {
                            error = "Sin Datos";
                            obj.dt.Dispose();
                            return false;
                        }
                        else
                        {
                            dt = obj.dt.Copy();
                            obj.dt.Dispose();
                            obj.dt = null;
                            return true;
                        }
                    }
                    else
                    {
                        error = obj.error;
                        obj.dt.Dispose();
                        return false;
                    }
                }
                else
                {
                    this.error = "Error1: " + obj.error;
                    img.Dispose();
                    ms.Dispose();
                    return false;
                }
            }
            catch (Exception er)
            {
                this.error = "Error3: " + er.ToString();
                return false;
            }
        }

        public bool archivar_datos2(string idvigilante, string marc, string agen, string io, string depto, string repuve, string placa, string vin, string foliofactura, string nombrefoto, byte[] imagen)
        {
            try
            {
                wfunciones1 obj = new wfunciones1();
                MemoryStream ms = new MemoryStream(imagen);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                /////Bitmap img2 = new Bitmap(img);
                DateTime hoy = DateTime.Now;

                if (existe_archivo(nombrefoto)) { /*si existe*/   File.Delete(System.Web.HttpContext.Current.Server.MapPath("~/ceo/" + nombrefoto)); }
                img.Save(System.Web.HttpContext.Current.Server.MapPath("~/ceo/" + nombrefoto), System.Drawing.Imaging.ImageFormat.Jpeg);

                if (obj.data("insert", "", "'" + idvigilante + "','" + marc + "','" + agen + "','" + io + "','" + depto + "','" + repuve + "','" + placa + "','" + vin + "','" + foliofactura + "','" + nombrefoto + "','" + hoy.ToString("dd/MM/yyyy") + "','" + hoy.ToString("HH:mm") + "'", "Tioautos", ""))
                {
                    img.Dispose();
                    ms.Dispose();
                    return true;
                }
                else
                {
                    this.error = "Error1: " + obj.error;
                    img.Dispose();
                    ms.Dispose();
                    return false;
                }
            }
            catch (Exception er)
            {
                this.error = "Error3: " + er.ToString();
                return false;
            }
        }

        public bool archivar_reporte_rondin(string Marca,string Agencia,string registroNFC,string iduser,string prioridad,string nombrefoto,string reporte,string fecha,string hora,byte[] imagen)
        {
            try
            {
                wfunciones1 obj = new wfunciones1();
                MemoryStream ms = new MemoryStream(imagen);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                /////Bitmap img2 = new Bitmap(img);
                DateTime hoy = DateTime.Now;

                if (existe_archivo(nombrefoto)) { /*si existe*/   File.Delete(System.Web.HttpContext.Current.Server.MapPath("~/ceo/" + nombrefoto)); }
                img.Save(System.Web.HttpContext.Current.Server.MapPath("~/ceo/" + nombrefoto), System.Drawing.Imaging.ImageFormat.Jpeg);

                if (obj.data("insert", "", "'" + iduser + "','" + Marca + "','" + Agencia + "','" + registroNFC + "','" + prioridad + "','" + nombrefoto + "','" + reporte + "','" + fecha + "','" + hora + "','" + hoy.ToString("dd/MM/yyyy") + "','" + hoy.ToString("HH:mm") + "'", "Treporterondin", ""))
                {
                    img.Dispose();
                    ms.Dispose();
                    if (prioridad == "red") sendcorreo(Marca,Agencia,registroNFC,iduser,prioridad,nombrefoto,reporte,hoy.ToString("dd/MM/yyyy"),hoy.ToString("HH:mm"));
                    return true;
                }
                else
                {
                    this.error = "Error11: " + obj.error;
                    img.Dispose();
                    ms.Dispose();
                    return false;
                }
            }
            catch (Exception er)
            {
                this.error = "Error33: " + er.ToString();
                return false;
            }
        }

        private bool existe_archivo(String cad)
        {
            return File.Exists(System.Web.HttpContext.Current.Server.MapPath("~/ceo/" + cad));
        }

        private void sendcorreo(string Marca, string Agencia,string registroNFC, string iduser, string prioridad, string nombrefoto, string reporte, string fecha, string hora)
        {
            try
            {
                wfunciones1 obj = new wfunciones1();
                string correosadmins = "",correosagencias="";


                if (obj.show_sql("select * from Emailadministradores"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        //
                    }
                    else
                    {
                        correosadmins = obj.dt.Rows[0][0].ToString().Trim();
                        obj.dt.Dispose();
                        obj.dt = null;
                    }
                }
                
                if (obj.show_sql("select * from Emailadmin where marca='" + Marca + "' and agencia='" + Agencia + "' order by id"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        //
                    }
                    else
                    {
                        if (obj.dt.Rows[0][3].ToString().Trim() != "") correosagencias += obj.dt.Rows[0][3].ToString().Trim() + ",";
                        if (obj.dt.Rows[0][4].ToString().Trim() != "") correosagencias += obj.dt.Rows[0][4].ToString().Trim() + ",";
                        if (obj.dt.Rows[0][5].ToString().Trim() != "") correosagencias += obj.dt.Rows[0][5].ToString().Trim() + ",";

                        if (correosagencias != "") correosagencias = correosagencias.Substring(0, (correosagencias.Length - 1));

                        obj.dt.Dispose();
                        obj.dt = null;
                    }
                }

                StringBuilder builder3;
                builder3 = new StringBuilder();
                builder3.Append("<center>\n");
                builder3.Append("<table cellpadding='5' cellspacing='0' border='0'>\n");
                builder3.Append("<tbody>\n");
                builder3.Append("<tr><td colspan='3' style='font-size:15px;background-color:#0c7fa8;color:#ffffff'>DATOS:</td></tr>\n");
                builder3.Append("<tr><td bgcolor='#990099' align='right' style='font-family:Arial;font-weight:bold;color:#ffffff' width='300'>MARCA:</td><td bgcolor='#669999' align='left' style='font-family:Arial;color:#ccccff' width='500'>" + Marca + "</td><td rowspan='8'><img width='300' height='600' src=cid:myImageID></td></tr>\n");
                builder3.Append("<tr><td bgcolor='#990099' align='right' style='font-family:Arial;font-weight:bold;color:#ffffff' width='300'>AGENCIA:</td><td bgcolor='#669999' align='left' style='font-family:Arial;color:#ccccff' width='500'>" + Agencia + "</td></tr>\n");
                builder3.Append("<tr><td bgcolor='#990099' align='right' style='font-family:Arial;font-weight:bold;color:#ffffff' width='300'>REGISTRONFC:</td><td bgcolor='#669999' align='left' style='font-family:Arial;color:#ccccff' width='500'>" + registroNFC + "</td></tr>\n");
                builder3.Append("<tr><td bgcolor='#990099' align='right' style='font-family:Arial;font-weight:bold;color:#ffffff' width='300'>IDVIGILANTE:</td><td bgcolor='#669999' align='left' style='font-family:Arial;color:#ccccff' width='500'>" + iduser + "</td></tr>\n");
                builder3.Append("<tr><td bgcolor='#990099' align='right' style='font-family:Arial;font-weight:bold;color:#ffffff' width='300'>PRIORIDAD:</td><td bgcolor='#669999' align='left' style='font-family:Arial;color:#ccccff' width='500'>" + prioridad + "</td></tr>\n");
                builder3.Append("<tr><td bgcolor='#990099' align='right' style='font-family:Arial;font-weight:bold;color:#ffffff' width='300'>FECHA:</td><td bgcolor='#669999' align='left' style='font-family:Arial;color:#ccccff' width='500'>" + fecha + "</td></tr>\n");
                builder3.Append("<tr><td bgcolor='#990099' align='right' style='font-family:Arial;font-weight:bold;color:#ffffff' width='300'>HORA:</td><td bgcolor='#669999' align='left' style='font-family:Arial;color:#ccccff' width='500'>" + hora + "</td></tr>\n");
                builder3.Append("<tr><td bgcolor='#990099' align='right' style='font-family:Arial;font-weight:bold;color:#ffffff' width='300'>REPORTE:</td><td bgcolor='#669999' align='left' style='font-family:Arial;color:#ccccff' width='500'>" + reporte + "</td></tr>\n");
                builder3.Append("</tbody>\n");
                builder3.Append("</table>\n");
                builder3.Append("</center>\n");

                if (sendero_rondin("caronemsg@carone.com.mx",correosagencias, correosadmins, "", "Reporte Rondin", "", builder3.ToString(), "ansinaes", nombrefoto))
                {
                    //
                }
                else
                {
                    //
                }
            }
            catch (Exception er)
            {
                //
            }
        }


        private bool sendero_rondin(String from, String to, String cc, String bcc, String subject, String text, String html, String pass, String atachimage)
        {
            try
            {
                int i;
                MailMessage correo1 = new MailMessage();
                SmtpClient smtp1 = new SmtpClient();
                if (from == "") return false;
                else correo1.From = new MailAddress(from);
                if (to == "") return false;
                else
                {
                    string[] para = Regex.Split(to, ",");
                    for (i = 0; i < para.Length; i++)
                    {
                        if (para[i].ToString() != "") correo1.To.Add(para[i]);
                    }
                }
                if (cc != "")
                {
                    string[] copias = Regex.Split(cc, ",");
                    for (i = 0; i < copias.Length; i++)
                    {
                        if (copias[i] != "") correo1.CC.Add(copias[i]);
                    }
                }
                if (bcc != "")
                {
                    string[] hiden_copias = Regex.Split(bcc, ",");
                    for (i = 0; i < hiden_copias.Length; i++)
                    {
                        if (hiden_copias[i] != "") correo1.Bcc.Add(hiden_copias[i]);
                    }
                }

                //Add Image
                /////////////LinkedResource theEmailImage = new LinkedResource(base.Server.MapPath("~/qrsupport/" + atachimage));
                LinkedResource theEmailImage = new LinkedResource(System.Web.HttpContext.Current.Server.MapPath("~/ceo/" + atachimage));
                theEmailImage.ContentId = "myImageID";

                correo1.Subject = subject;
                AlternateView item = AlternateView.CreateAlternateViewFromString(text, null, "text/plain");
                AlternateView view2 = AlternateView.CreateAlternateViewFromString(html, null, "text/html");
                view2.LinkedResources.Add(theEmailImage);
                correo1.Body = "";
                correo1.IsBodyHtml = true;
                correo1.AlternateViews.Add(item);
                correo1.AlternateViews.Add(view2);
                correo1.Priority = MailPriority.Normal;

                //smtp1.Host = "192.168.11.97";
                smtp1.Host = "192.168.11.190";
                smtp1.Port = 25;

                smtp1.Credentials = new NetworkCredential(from, pass);
                smtp1.Send(correo1);
                correo1 = null;
                smtp1 = null;
                item = null;
                view2 = null;
                return true;
            }
            catch (Exception er)
            {
                return false;
            }
        }



        public bool mandarcartas()
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from carta_check where envio='' order by id"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.dt.Dispose();
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool questupdates()
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from tabla_updates order by clave"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.dt.Dispose();
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool newquestlogin()
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Tusersquesttablets order by marc,agen,id"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool insert_rs_status(String id_lead, String marca, String agencia, String status, String fecha, String hora, String fechacita, String horacita, String tipostatus, String folio)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                String latabla, cadena, layers = "", layers2 = "", tiempo = "", cadenota = "", cad_update = "";
                TimeSpan start, end, now;
                int lashoras;
                latabla = "rs_status";

                if (agencia == "SANJE") agencia = "SAN JERONIMO";
                if (agencia == "PROLONGACIÓN MADERO") agencia = "P. MADERO";

                if (!(status == "Por Confirmar" || status == "Reagendar Cita"))
                {
                    fechacita = "";
                    horacita = "";
                }

                //checo si es repetido de doble click
                cadena = "select * from " + latabla + " where id_lead='" + id_lead + "'";

                if (obj.show_sql(cadena))
                {
                    layers = obj.dt.Rows[0][4].ToString().Trim();
                    if (layers == "") layers = status + ",";
                    else layers += status + ",";

                    layers2 = obj.dt.Rows[0][19].ToString().Trim();
                    if (layers2 == "") layers2 = status + ",";
                    else layers2 += status + ",";

                    if (tipostatus == "lead")
                    {
                        if (status == "Cita Por Confirmar" || status == "Reagendar Cita")
                        {
                            cad_update = "layers='" + layers + "',status='" + status + "',fechacita='" + fechacita + "',horacita='" + horacita + "',tipostatus='" + tipostatus + "'";
                        }
                        else
                        {
                            cad_update = "layers='" + layers + "',status='" + status + "'";
                        }
                    }
                    else if (tipostatus == "cita")
                    {
                        if (status == "Por Confirmar" || status == "Reagendar Cita")
                        {
                            cad_update = "layers2='" + layers + "',status2='" + status + "',fechacita='" + fechacita + "',horacita='" + horacita + "',tipostatus='" + tipostatus + "'";
                        }
                        else
                        {
                            cad_update = "layers2='" + layers + "',status2='" + status + "'";
                        }
                    }

                    if (obj.data("update", "", cad_update, latabla, "id_lead=" + id_lead))
                    {
                        cad_JSON = "Dato Archivado";
                        return true;
                    }
                    else
                    {
                        this.error = "Error: " + obj.error;
                        return false;
                    }

                }
                else
                {
                    DateTime hoy = DateTime.Now;

                    if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
                    {
                        tiempo = "dt";
                    }
                    else if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
                    {
                        lashoras = int.Parse(DateTime.Now.ToString("HH"));
                        if ((lashoras < 9) || (lashoras > 13))
                        {
                            tiempo = "dt";
                        }
                        else
                        {
                            tiempo = "at";
                        }
                    }
                    else
                    {
                        start = new TimeSpan(9, 0, 0);
                        end = new TimeSpan(19, 0, 0);
                        now = DateTime.Now.TimeOfDay;

                        if (((now > start) && (now < end)))
                        {
                            tiempo = "at";
                        }
                        else
                        {
                            tiempo = "dt";
                        }
                    }

                    if (tipostatus == "lead")
                    {
                        cadenota = "'" + id_lead + "','" + marca + "','" + agencia + "','" + layers + "','" + status + "','" + fecha + "','" + hora + "','" + hoy.ToString("dd/MM/yyyy") + "','" + hoy.ToString("HH:mm:ss") + "','','','','" + tiempo + "','" + fechacita + "','" + horacita + "','','','','','','" + tipostatus + "','" + folio + "'";
                    }
                    else if (tipostatus == "cita")
                    {
                        cadenota = "'" + id_lead + "','" + marca + "','" + agencia + "','','','" + fecha + "','" + hora + "','" + hoy.ToString("dd/MM/yyyy") + "','" + hoy.ToString("HH:mm:ss") + "','','','','" + tiempo + "','" + fechacita + "','" + horacita + "','','','','" + layers2 + "','" + status + "','" + tipostatus + "','" + folio + "'";
                    }

                    if (obj.data("insert", "", cadenota, latabla, ""))
                    {
                        /********if (status == "Cita Por Confirmar" || status == "Reagendar Cita") get_fecha(id_lead);*****/

                        cad_JSON = "Dato Archivado";
                        return true;
                    }
                    else
                    {
                        this.error = "Error: " + obj.error;
                        return false;
                    }
                }

                /*****
                
                    if (obj.error == "Sin Datos")
                    {
                        if (obj.data("insert", "", "'" + marca + "','" + agencia + "','" + nombre + "','" + telefono + "','" + email + "','" + acuenta + "','" + modelo + "','',''", latabla, ""))
                        {
                            cad_JSON = "Dato Archivado";
                            return true;
                        }
                        else
                        {
                            this.error = "Error: " + obj.error;
                            return false;
                        }
                    }
                    else
                    {
                        this.error = "Error: " + obj.error;
                        return false;
                    }
                }****/
            }
            catch (Exception er)
            {
                this.error = "Error: " + er.ToString();
                obj = null;
                return false;
            }
        }

        public bool insert_rs_status2(String id_lead, String marca, String agencia, String status, String fecha, String hora, String fechacita, String horacita, String tipostatus, String folio)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                String latabla, cadena, layers = "", layers2 = "", tiempo = "", cadenota = "", cad_update = "";
                TimeSpan start, end, now;
                int lashoras;
                latabla = "rs_status2";

                if (agencia == "SANJE") agencia = "SAN JERONIMO";
                if (agencia == "PROLONGACIÓN MADERO") agencia = "P. MADERO";

                if (!(status == "Por Confirmar" || status == "Reagendar Cita"))
                {
                    fechacita = "";
                    horacita = "";
                }

                //checo si es repetido de doble click
                cadena = "select * from " + latabla + " where id_lead='" + id_lead + "'";

                if (obj.show_sql(cadena))
                {
                    layers = obj.dt.Rows[0][4].ToString().Trim();
                    if (layers == "") layers = status + ",";
                    else layers += status + ",";

                    layers2 = obj.dt.Rows[0][19].ToString().Trim();
                    if (layers2 == "") layers2 = status + ",";
                    else layers2 += status + ",";

                    if (tipostatus == "lead")
                    {
                        if (status == "Cita Por Confirmar" || status == "Reagendar Cita")
                        {
                            cad_update = "layers='" + layers + "',status='" + status + "',fechacita='" + fechacita + "',horacita='" + horacita + "',tipostatus='" + tipostatus + "'";
                        }
                        else
                        {
                            cad_update = "layers='" + layers + "',status='" + status + "'";
                        }
                    }
                    else if (tipostatus == "cita")
                    {
                        if (status == "Por Confirmar" || status == "Reagendar Cita")
                        {
                            cad_update = "layers2='" + layers + "',status2='" + status + "',fechacita='" + fechacita + "',horacita='" + horacita + "',tipostatus='" + tipostatus + "'";
                        }
                        else
                        {
                            cad_update = "layers2='" + layers + "',status2='" + status + "'";
                        }
                    }

                    if (obj.data("update", "", cad_update, latabla, "id_lead=" + id_lead))
                    {
                        cad_JSON = "Dato Archivado";
                        return true;
                    }
                    else
                    {
                        this.error = "Error: " + obj.error;
                        return false;
                    }

                }
                else
                {
                    DateTime hoy = DateTime.Now;

                    if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
                    {
                        tiempo = "dt";
                    }
                    else if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
                    {
                        lashoras = int.Parse(DateTime.Now.ToString("HH"));
                        if ((lashoras < 9) || (lashoras > 13))
                        {
                            tiempo = "dt";
                        }
                        else
                        {
                            tiempo = "at";
                        }
                    }
                    else
                    {
                        start = new TimeSpan(9, 0, 0);
                        end = new TimeSpan(19, 0, 0);
                        now = DateTime.Now.TimeOfDay;

                        if (((now > start) && (now < end)))
                        {
                            tiempo = "at";
                        }
                        else
                        {
                            tiempo = "dt";
                        }
                    }

                    if (tipostatus == "lead")
                    {
                        cadenota = "'" + id_lead + "','" + marca + "','" + agencia + "','" + layers + "','" + status + "','" + fecha + "','" + hora + "','" + hoy.ToString("dd/MM/yyyy") + "','" + hoy.ToString("HH:mm:ss") + "','','','','" + tiempo + "','" + fechacita + "','" + horacita + "','','','','','','" + tipostatus + "','" + folio + "'";
                    }
                    else if (tipostatus == "cita")
                    {
                        cadenota = "'" + id_lead + "','" + marca + "','" + agencia + "','','','" + fecha + "','" + hora + "','" + hoy.ToString("dd/MM/yyyy") + "','" + hoy.ToString("HH:mm:ss") + "','','','','" + tiempo + "','" + fechacita + "','" + horacita + "','','','','" + layers2 + "','" + status + "','" + tipostatus + "','" + folio + "'";
                    }

                    if (obj.data("insert", "", cadenota, latabla, ""))
                    {
                        /********if (status == "Cita Por Confirmar" || status == "Reagendar Cita") get_fecha(id_lead);*****/

                        cad_JSON = "Dato Archivado";
                        return true;
                    }
                    else
                    {
                        this.error = "Error: " + obj.error;
                        return false;
                    }
                }

            }
            catch (Exception er)
            {
                this.error = "Error: " + er.ToString();
                obj = null;
                return false;
            }
        }


        private void get_fecha(String id_lead)
        {
            try
            {
                String puntosfinales, cfecha = "", chora = "";
                String[] pedazos1, pedazos2;
                SMS_referencia.servicioSoapClient webserv = new SMS_referencia.servicioSoapClient();
                puntosfinales = webserv.rs_prospecto(id_lead);
                pedazos1 = Regex.Split(puntosfinales, "\\%\\&");

                if (pedazos1.Length > 23)
                {
                    pedazos2 = Regex.Split(pedazos1[22], "\\#\\+");
                    if (pedazos2.Length > 1)
                    {
                        cfecha = pedazos2[1];
                        cfecha = cfecha.Substring(8, 2) + "/" + cfecha.Substring(5, 2) + "/" + cfecha.Substring(0, 4);
                    }

                    pedazos2 = Regex.Split(pedazos1[23], "\\#\\+");
                    if (pedazos2.Length > 1)
                    {
                        chora = pedazos2[1];
                        chora = chora.Substring(0, 5);
                    }

                    wfunciones1 obj3 = new wfunciones1();
                    if (obj3.data("update", "", "fechacita='" + cfecha + "',horacita='" + chora + "'", "rs_status", "id_lead=" + id_lead))
                    {
                        //todo bien
                    }
                }
            }
            catch (Exception er)
            {
                this.error += "Error: " + er.ToString();
            }
        }

        public bool rsalertusers(String marca, String agencia)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select nombres,apellidos,nivel,email,tel,agencias from Tlogin_rsalert where agencias like '%" + marca + "-" + agencia + "%' or agencias='CORPORATIVO'"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool resumenrs()
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                int i, j, k;
                String sql, dia2, gran_cadena = "";
                String[] nivel, arr1, arr2, arr3, arr4;
                DateTime hoy, tercer_mes;

                hoy = DateTime.Now;
                tercer_mes = hoy.AddMonths(-2);
                dia2 = hoy.ToString("dd");

                ///mes_actual = hoy.ToString("dd/MM/yyyy");
                nivel = new String[3];
                nivel[0] = "ss!=''";
                nivel[1] = "sg!=''";
                nivel[2] = "sd!=''";

                for (i = 0; i < 3; i++)
                {
                    sql = "select CAST(SUBSTRING(fecha2,4,2) AS INT) as mes,CAST(SUBSTRING(fecha2,7,4) AS INT) as anio,count(*) as alertas from rs_status with (nolock) where CAST(SUBSTRING(fecha2,1,2) AS INT)>=CAST(01 AS INT) and CAST(SUBSTRING(fecha2,1,2) AS INT)<=CAST(" + dia2 + " AS INT) and CONVERT(SmallDateTime, fecha2, 103) between CONVERT(SmallDateTime, '01/" + tercer_mes.ToString("MM") + "/" + tercer_mes.ToString("yyyy") + "', 103) and CONVERT(SmallDateTime, '" + hoy.ToString("dd/MM/yyyy") + "', 103) and " + nivel[i] + " group by CAST(SUBSTRING(fecha2,7,4) AS INT),CAST(SUBSTRING(fecha2,4,2) AS INT) order by CAST(SUBSTRING(fecha2,7,4) AS INT),CAST(SUBSTRING(fecha2,4,2) AS INT)";
                    //Response.Write(sql);
                    if (get_dato(sql))
                    {
                        //gv.DataSource = aux;
                        //gv.DataBind();
                        for (j = 0; j < dt.Rows.Count; j++)
                        {
                            for (k = 0; k < dt.Columns.Count; k++) gran_cadena += dt.Rows[j][k].ToString() + "||";
                            gran_cadena = gran_cadena.Substring(0, (gran_cadena.Length - 2)) + "%&";
                        }

                        gran_cadena = gran_cadena.Substring(0, (gran_cadena.Length - 2)) + "!!";

                        sql = "select CAST(SUBSTRING(fecha2,4,2) AS INT) as mes,CAST(SUBSTRING(fecha2,7,4) AS INT) as anio,marca,count(*) as alertas from rs_status with (nolock) where CAST(SUBSTRING(fecha2,1,2) AS INT)>=CAST(01 AS INT) and CAST(SUBSTRING(fecha2,1,2) AS INT)<=CAST(" + dia2 + " AS INT) and CONVERT(SmallDateTime, fecha2, 103) between CONVERT(SmallDateTime, '01/" + tercer_mes.ToString("MM") + "/" + tercer_mes.ToString("yyyy") + "', 103) and CONVERT(SmallDateTime, '" + hoy.ToString("dd/MM/yyyy") + "', 103) and " + nivel[i] + " group by CAST(SUBSTRING(fecha2,7,4) AS INT),CAST(SUBSTRING(fecha2,4,2) AS INT),marca order by CAST(SUBSTRING(fecha2,7,4) AS INT),CAST(SUBSTRING(fecha2,4,2) AS INT),marca";
                        //Response.Write("<br/><br/><br/>" + sql);
                        if (get_dato(sql))
                        {
                            //gv1.DataSource = aux;
                            //gv1.DataBind();
                            for (j = 0; j < dt.Rows.Count; j++)
                            {
                                for (k = 0; k < dt.Columns.Count; k++) gran_cadena += dt.Rows[j][k].ToString() + "||";
                                gran_cadena = gran_cadena.Substring(0, (gran_cadena.Length - 2)) + "%&";
                            }

                            gran_cadena = gran_cadena.Substring(0, (gran_cadena.Length - 2)) + "!!";

                            sql = "select CAST(SUBSTRING(fecha2,4,2) AS INT) as mes,CAST(SUBSTRING(fecha2,7,4) AS INT) as anio,marca,agencia,count(*) as alertas from rs_status with (nolock) where CAST(SUBSTRING(fecha2,1,2) AS INT)>=CAST(01 AS INT) and CAST(SUBSTRING(fecha2,1,2) AS INT)<=CAST(" + dia2 + " AS INT) and CONVERT(SmallDateTime, fecha2, 103) between CONVERT(SmallDateTime, '01/" + tercer_mes.ToString("MM") + "/" + tercer_mes.ToString("yyyy") + "', 103) and CONVERT(SmallDateTime, '" + hoy.ToString("dd/MM/yyyy") + "', 103) and " + nivel[i] + " group by CAST(SUBSTRING(fecha2,7,4) AS INT),CAST(SUBSTRING(fecha2,4,2) AS INT),marca,agencia order by CAST(SUBSTRING(fecha2,7,4) AS INT),CAST(SUBSTRING(fecha2,4,2) AS INT),marca,agencia";
                            //Response.Write("<br/><br/><br/>" + sql);
                            if (get_dato(sql))
                            {
                                //gv2.DataSource = aux;
                                //gv2.DataBind();
                                for (j = 0; j < dt.Rows.Count; j++)
                                {
                                    for (k = 0; k < dt.Columns.Count; k++) gran_cadena += dt.Rows[j][k].ToString() + "||";
                                    gran_cadena = gran_cadena.Substring(0, (gran_cadena.Length - 2)) + "%&";
                                }

                                gran_cadena = gran_cadena.Substring(0, (gran_cadena.Length - 2)) + "!!";

                                sql = "select CAST(SUBSTRING(fecha2,4,2) AS INT) as mes,CAST(SUBSTRING(fecha2,7,4) AS INT) as anio,marca,agencia,tiempo,count(*) as alertas from rs_status with (nolock) where CAST(SUBSTRING(fecha2,1,2) AS INT)>=CAST(01 AS INT) and CAST(SUBSTRING(fecha2,1,2) AS INT)<=CAST(" + dia2 + " AS INT) and CONVERT(SmallDateTime, fecha2, 103) between CONVERT(SmallDateTime, '01/" + tercer_mes.ToString("MM") + "/" + tercer_mes.ToString("yyyy") + "', 103) and CONVERT(SmallDateTime, '" + hoy.ToString("dd/MM/yyyy") + "', 103) and " + nivel[i] + " group by CAST(SUBSTRING(fecha2,7,4) AS INT),CAST(SUBSTRING(fecha2,4,2) AS INT),marca,agencia,tiempo order by CAST(SUBSTRING(fecha2,7,4) AS INT),CAST(SUBSTRING(fecha2,4,2) AS INT),marca,agencia,tiempo";
                                //Response.Write("<br/><br/><br/>" + sql);
                                if (get_dato(sql))
                                {
                                    //gv3.DataSource = aux;
                                    //gv3.DataBind();
                                    for (j = 0; j < dt.Rows.Count; j++)
                                    {
                                        for (k = 0; k < dt.Columns.Count; k++) gran_cadena += dt.Rows[j][k].ToString() + "||";
                                        gran_cadena = gran_cadena.Substring(0, (gran_cadena.Length - 2)) + "%&";
                                    }

                                    gran_cadena = gran_cadena.Substring(0, (gran_cadena.Length - 2));
                                }
                            }
                        }
                    }

                    gran_cadena += "$#";


                }


                lacadena = gran_cadena.Substring(0, (gran_cadena.Length - 2));
                return true;
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }


        public bool resumenrs2(String agencia)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                int i, j, k;
                String sql, gran_cadena = "", mes, anio, cadenita = "";
                String[] nivel;
                DateTime hoy, ayer;

                hoy = DateTime.Now;
                ayer = DateTime.Now.AddDays(-1);
                mes = hoy.ToString("MM");
                anio = hoy.ToString("yyyy");

                ///mes_actual = hoy.ToString("dd/MM/yyyy");                
                nivel = new String[3];
                nivel[0] = "ss!=''";
                nivel[1] = "sg!=''";
                nivel[2] = "sd!=''";

                for (i = 0; i < 3; i++)
                {
                    sql = "select marca,agencia,count(*) as alertas from rs_status with (nolock) where " + nivel[i] + " and CONVERT(SmallDateTime, fecha2, 103) between CONVERT(SmallDateTime, '01/" + mes + "/" + anio + "', 103) and CONVERT(SmallDateTime, '" + hoy.ToString("dd/MM/yyyy") + "', 103) group by marca,agencia order by marca,agencia";
                    //Response.Write(sql);
                    if (get_dato(sql))
                    {
                        //gv.DataSource = aux;
                        //gv.DataBind();
                        for (j = 0; j < dt.Rows.Count; j++)
                        {
                            for (k = 0; k < dt.Columns.Count; k++) gran_cadena += dt.Rows[j][k].ToString() + "||";
                            gran_cadena = gran_cadena.Substring(0, (gran_cadena.Length - 2)) + "%&";
                        }

                        gran_cadena = gran_cadena.Substring(0, (gran_cadena.Length - 2)) + "!!";


                        if (i == 2) sql = "select marca,agencia,count(*) as alertas from rs_status with (nolock) where " + nivel[i] + " and fecha2='" + ayer.ToString("dd/MM/yyyy") + "' group by marca,agencia order by marca,agencia";
                        else sql = "select marca,agencia,count(*) as alertas from rs_status with (nolock) where " + nivel[i] + " and fecha2='" + hoy.ToString("dd/MM/yyyy") + "' group by marca,agencia order by marca,agencia";

                        //Response.Write("<br/><br/><br/>" + sql);
                        if (get_dato(sql))
                        {
                            //gv1.DataSource = aux;
                            //gv1.DataBind();
                            for (j = 0; j < dt.Rows.Count; j++)
                            {
                                for (k = 0; k < dt.Columns.Count; k++) gran_cadena += dt.Rows[j][k].ToString() + "||";
                                gran_cadena = gran_cadena.Substring(0, (gran_cadena.Length - 2)) + "%&";
                            }

                            gran_cadena = gran_cadena.Substring(0, (gran_cadena.Length - 2));
                        }
                    }

                    gran_cadena += "$#";
                }

                lacadena = gran_cadena.Substring(0, (gran_cadena.Length - 2));

                sql = "select A.marca,A.agencia,T.nombres,T.apellidos,T.tel from rs_status as A INNER JOIN (select agencias,nombres,apellidos,tel from Tlogin_rsalert where nivel='sg') as T ON T.agencias like '%' + A.marca + '-' + A.agencia + '%' where A.sd!='' and CONVERT(SmallDateTime, fecha2, 103) between CONVERT(SmallDateTime, '01/" + mes + "/" + anio + "', 103) and CONVERT(SmallDateTime, '" + hoy.ToString("dd/MM/yyyy") + "', 103) group by marca,agencia,T.nombres,T.apellidos,T.tel order by marca,agencia";
                if (get_dato(sql))
                {
                    for (j = 0; j < dt.Rows.Count; j++)
                    {
                        for (k = 0; k < dt.Columns.Count; k++) cadenita += dt.Rows[j][k].ToString() + "||";
                        cadenita = cadenita.Substring(0, (cadenita.Length - 2)) + "%&";
                    }
                }

                if (cadenita == "") lacadena += "¿¿";
                else lacadena += "¿¿" + cadenita.Substring(0, (cadenita.Length - 2));

                return true;
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool resumenrs3()
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                int i, j, k;
                String sql, gran_cadena = "", mes, anio;
                String[] nivel;
                DateTime hoy, ayer;

                hoy = DateTime.Now;
                //ayer = DateTime.Now.AddDays(-1);
                mes = hoy.ToString("MM");
                anio = hoy.ToString("yyyy");

                ///mes_actual = hoy.ToString("dd/MM/yyyy");                
                nivel = new String[3];
                nivel[0] = "ss!=''";
                nivel[1] = "sg!=''";
                nivel[2] = "sd!=''";

                for (i = 0; i < 3; i++)
                {
                    sql = "select marca,agencia,CAST(SUBSTRING(fecha2,4,2) AS INT) as mes,CAST(SUBSTRING(fecha2,7,4) AS INT) as anio,count(*) as alertas from rs_status with (nolock) where " + nivel[i] + " and CONVERT(SmallDateTime, fecha2, 103) between CONVERT(SmallDateTime, '01/01/" + anio + "', 103) and CONVERT(SmallDateTime, '" + hoy.ToString("dd/MM/yyyy") + "', 103) group by marca,agencia,CAST(SUBSTRING(fecha2,7,4) AS INT),CAST(SUBSTRING(fecha2,4,2) AS INT) order by anio,mes,marca,agencia";

                    if (get_dato(sql))
                    {
                        for (j = 0; j < dt.Rows.Count; j++)
                        {
                            for (k = 0; k < dt.Columns.Count; k++) gran_cadena += dt.Rows[j][k].ToString() + "||";
                            gran_cadena = gran_cadena.Substring(0, (gran_cadena.Length - 2)) + "%&";
                        }

                        gran_cadena = gran_cadena.Substring(0, (gran_cadena.Length - 2)) + "!!";
                    }
                }

                lacadena = gran_cadena.Substring(0, (gran_cadena.Length - 2));
                return true;
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool resumenrs4()
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                //select marca,agencia,tipoenc,CAST(SUBSTRING(fecha,4,2) AS INT) as mes,CAST(SUBSTRING(fecha,7,4) AS INT) as anio,count(*) as alertas from Talarmas with (nolock) where sms='si' and CONVERT(SmallDateTime, fecha, 103) between CONVERT(SmallDateTime, '01/01/2019', 103) and CONVERT(SmallDateTime, '31/12/2019', 103) group by marca,agencia,tipoenc,CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT) order by anio,mes,marca,agencia,tipoenc
                //select marca,agencia,tipoenc,fecha,count(*) as alertas from Talarmas with (nolock) where sms='si' and fecha= '25/09/2019' group by marca,agencia,tipoenc,fecha order by marca,agencia,tipoenc

                int j, k;
                String sql, gran_cadena = "", mes, anio, cadenita = "";
                lacadena = "";
                DateTime hoy;

                hoy = DateTime.Now;
                //ayer = DateTime.Now.AddDays(-1);
                mes = hoy.ToString("MM");
                anio = hoy.ToString("yyyy");

                sql = "select marca,agencia,tipoenc,CAST(SUBSTRING(fecha,4,2) AS INT) as mes,CAST(SUBSTRING(fecha,7,4) AS INT) as anio,count(*) as alertas from Talarmas with (nolock) where sms='si' and CAST(SUBSTRING(fecha,4,2) AS INT)='" + mes + "' and CAST(SUBSTRING(fecha,7,4) AS INT)='" + anio + "' group by marca,agencia,tipoenc,CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT) order by anio,mes,marca,agencia,tipoenc";
                if (get_dato(sql))
                {
                    for (j = 0; j < dt.Rows.Count; j++)
                    {
                        for (k = 0; k < dt.Columns.Count; k++) gran_cadena += dt.Rows[j][k].ToString() + "||";
                        gran_cadena = gran_cadena.Substring(0, (gran_cadena.Length - 2)) + "%&";
                    }

                    gran_cadena = gran_cadena.Substring(0, (gran_cadena.Length - 2));
                }
                else
                {
                    if (error != "Sin Datos") return false;
                }

                lacadena = gran_cadena + "!!";
                gran_cadena = "";

                sql = "select marca,agencia,tipoenc,CAST(SUBSTRING(fecha,4,2) AS INT) as mes,CAST(SUBSTRING(fecha,7,4) AS INT) as anio,count(*) as alertas from Talarmas with (nolock) where sms='si' and fecha='" + hoy.ToString("dd/MM/yyyy") + "' group by marca,agencia,tipoenc,CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT) order by anio,mes,marca,agencia,tipoenc ";
                if (get_dato(sql))
                {
                    for (j = 0; j < dt.Rows.Count; j++)
                    {
                        for (k = 0; k < dt.Columns.Count; k++) gran_cadena += dt.Rows[j][k].ToString() + "||";
                        gran_cadena = gran_cadena.Substring(0, (gran_cadena.Length - 2)) + "%&";
                    }

                    gran_cadena = gran_cadena.Substring(0, (gran_cadena.Length - 2));
                }
                else
                {
                    if (error != "Sin Datos") return false;
                }

                lacadena += gran_cadena + "¿¿";

                //sql = "select A.marca,A.agencia,T.nombres,T.apellidos,T.tel from rs_status as A INNER JOIN (select agencias,nombres,apellidos,tel from Tlogin_rsalert where nivel='sg') as T ON T.agencias like '%' + A.marca + '-' + A.agencia + '%' where A.sd!='' and CONVERT(SmallDateTime, fecha2, 103) between CONVERT(SmallDateTime, '01/" + mes + "/" + anio + "', 103) and CONVERT(SmallDateTime, '" + hoy.ToString("dd/MM/yyyy") + "', 103) group by marca,agencia,T.nombres,T.apellidos,T.tel order by marca,agencia";
                sql = "select A.marca,A.agencia,T.nombres,T.apellidos,T.tel from Talarmas as A INNER JOIN (select agencias,nombres,apellidos,tel from Tloginalarmas) as T ON T.agencias like '%' + A.marca + '-' + A.agencia + '%' where A.sms='si' and CAST(SUBSTRING(fecha,4,2) AS INT)='" + mes + "' and CAST(SUBSTRING(fecha,7,4) AS INT)='" + anio + "' group by marca,agencia,T.nombres,T.apellidos,T.tel order by marca,agencia";
                if (get_dato(sql))
                {
                    for (j = 0; j < dt.Rows.Count; j++)
                    {
                        for (k = 0; k < dt.Columns.Count; k++) cadenita += dt.Rows[j][k].ToString() + "||";
                        cadenita = cadenita.Substring(0, (cadenita.Length - 2)) + "%&";
                    }
                }
                else
                {
                    if (error != "Sin Datos") return false;
                }

                if (cadenita != "") lacadena += cadenita.Substring(0, (cadenita.Length - 2));

                return true;
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool resumenrs5()
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                int i,j;
                DataTable tablas, aux;
                string sql1;
                string C_MARCA, C_AGENCIA, C_VFACTURADAS, C_PFACTURADAS, C_VENCUESTADAS, C_PENCUESTADAS, C_VPORCENTAJE, C_PPORCENTAJE, C_VALARMAS, C_PALARMAS;

                obj = new wfunciones1();
                tablas = new DataTable();
                tablas.Clear();
                tablas.Columns.Add("MARCA", typeof(string));
                tablas.Columns.Add("AGENCIA", typeof(string));
                tablas.Columns.Add("VFACTURADAS", typeof(string));
                tablas.Columns.Add("PFACTURADAS", typeof(string));
                tablas.Columns.Add("VENCUESTADAS", typeof(string));
                tablas.Columns.Add("PENCUESTADAS", typeof(string));
                tablas.Columns.Add("VPORCENTAJE", typeof(string));
                tablas.Columns.Add("PPORCENTAJE", typeof(string));
                tablas.Columns.Add("VALARMAS", typeof(string));
                tablas.Columns.Add("PALARMAS", typeof(string));

                //obtener agencias
                sql1 = "select * from lista_agencias with (nolock) order by marca,agencia";

                if (get_dato(sql1))
                {
                    aux = dt.Copy();
                    dt.Dispose();

                    for (i = 0; i < aux.Rows.Count; i++)
                    {
                        C_MARCA = "0"; C_AGENCIA = "0"; C_VFACTURADAS = "0"; C_PFACTURADAS = "0"; C_VENCUESTADAS = "0"; C_PENCUESTADAS = "0";
                        C_VPORCENTAJE = "0"; C_PPORCENTAJE = "0"; C_VALARMAS = "0"; C_PALARMAS = "0";
                        C_MARCA = aux.Rows[i][1].ToString();
                        C_AGENCIA = aux.Rows[i][2].ToString();

                        if (obj.conexion11("venta", C_MARCA, C_AGENCIA))
                        {
                            if (obj.dt.Rows.Count > 0) C_VFACTURADAS = obj.dt.Rows[0][2].ToString();
                            obj.dt.Dispose();
                        }

                        if (obj.conexion11("postventa", C_MARCA, C_AGENCIA))
                        {
                            if (obj.dt.Rows.Count > 0) C_PFACTURADAS = obj.dt.Rows[0][2].ToString();
                            obj.dt.Dispose();
                        }

                        //obtener encuestadas ventas
                        sql1 = "select CAST(SUBSTRING(fecha,4,2) AS INT) as mes,CAST(SUBSTRING(fecha,7,4) AS INT) as anio,COUNT(*) as encuestas from Tencuestas with (nolock) where marca='" + C_MARCA + "' and agencia='" + C_AGENCIA + "' and tipoenc='venta' and fecha like '%/" + DateTime.Now.ToString("MM").ToString() + "/" + DateTime.Now.ToString("yyyy").ToString() + "' group by CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT) order by CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT)";
                        C_VENCUESTADAS = obtener_dato(sql1);
                        dt.Dispose();
                        //obtener encuestadas postventas
                        sql1 = "select CAST(SUBSTRING(fecha,4,2) AS INT) as mes,CAST(SUBSTRING(fecha,7,4) AS INT) as anio,COUNT(*) as encuestas from Tencuestas with (nolock) where marca='" + C_MARCA + "' and agencia='" + C_AGENCIA + "' and tipoenc='postventa' and fecha like '%/" + DateTime.Now.ToString("MM").ToString() + "/" + DateTime.Now.ToString("yyyy").ToString() + "' group by CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT) order by CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT)";
                        C_PENCUESTADAS = obtener_dato(sql1);
                        dt.Dispose();

                        if (C_VFACTURADAS == "0") C_VPORCENTAJE = "0.00 %";
                        else C_VPORCENTAJE = ((float.Parse(C_VENCUESTADAS) / float.Parse(C_VFACTURADAS)) * 100).ToString("0.##") + " %";

                        if (C_PFACTURADAS == "0") C_PPORCENTAJE = "0.00 %";
                        else C_PPORCENTAJE = ((float.Parse(C_PENCUESTADAS) / float.Parse(C_PFACTURADAS)) * 100).ToString("0.##") + " %";

                        //obtener alarmas ventas
                        sql1 = "select CAST(SUBSTRING(fecha,4,2) AS INT) as mes,CAST(SUBSTRING(fecha,7,4) AS INT) as anio,COUNT(*) as alarmas from talarmas with (nolock) where marca='" + C_MARCA + "' and agencia='" + C_AGENCIA + "' and tipoenc='venta' and fecha like '%/" + DateTime.Now.ToString("MM").ToString() + "/" + DateTime.Now.ToString("yyyy").ToString() + "' group by CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT) order by CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT)";
                        C_VALARMAS = obtener_dato(sql1);
                        dt.Dispose();
                        //obtener alarmas postventas
                        sql1 = "select CAST(SUBSTRING(fecha,4,2) AS INT) as mes,CAST(SUBSTRING(fecha,7,4) AS INT) as anio,COUNT(*) as alarmas from talarmas with (nolock) where marca='" + C_MARCA + "' and agencia='" + C_AGENCIA + "' and tipoenc='postventa' and fecha like '%/" + DateTime.Now.ToString("MM").ToString() + "/" + DateTime.Now.ToString("yyyy").ToString() + "' group by CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT) order by CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT)";
                        C_PALARMAS = obtener_dato(sql1);
                        dt.Dispose();

                        tablas.Rows.Add(C_MARCA, C_AGENCIA, C_VFACTURADAS, C_PFACTURADAS, C_VENCUESTADAS, C_PENCUESTADAS, C_VPORCENTAJE, C_PPORCENTAJE, C_VALARMAS, C_PALARMAS);

                    }  //end for  ciclo de agencias
                }   //end lista_agencias

                lacadena = "";

                for (i = 0; i < tablas.Rows.Count; i++)
                {
                    for (j = 0; j < tablas.Columns.Count; j++) lacadena += tablas.Rows[i][j].ToString() + "||";

                    if (lacadena != "") lacadena = lacadena.Substring(0, (lacadena.Length - 2)) + "%&";                    
                }

                if (lacadena != "") lacadena = lacadena.Substring(0, (lacadena.Length - 2));

                return true;
            }
            catch (Exception er)
            {
                error = er.ToString();
                return false;
            }
        }

        public bool resumenrs6()
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                int i;
                DataTable aux;
                string sql1;
                string C_MARCA, C_AGENCIA, C_VFACTURADAS, C_PFACTURADAS;

                obj = new wfunciones1();
                
                //obtener agencias
                sql1 = "select * from lista_agencias with (nolock) order by marca,agencia";

                if (get_dato(sql1))
                {
                    aux = dt.Copy();
                    dt.Dispose();

                    sql1 = "IF OBJECT_ID('facturadasagencias', 'U') IS NOT NULL DROP TABLE facturadasagencias";
                    obj.mod_sql(sql1);
                    sql1 = "create table facturadasagencias (MARCA varchar(30),AGENCIA varchar(50),VFACTURADAS varchar(10),PFACTURADAS varchar(10))";
                    obj.mod_sql(sql1);

                    for (i = 0; i < aux.Rows.Count; i++)
                    {
                        C_MARCA = "0"; C_AGENCIA = "0"; C_VFACTURADAS = "0"; C_PFACTURADAS = "0";
                        C_MARCA = aux.Rows[i][1].ToString();
                        C_AGENCIA = aux.Rows[i][2].ToString();

                        if (obj.conexion11("venta", C_MARCA, C_AGENCIA))
                        {
                            if (obj.dt.Rows.Count > 0) C_VFACTURADAS = obj.dt.Rows[0][2].ToString();
                            obj.dt.Dispose();
                        }

                        if (obj.conexion11("postventa", C_MARCA, C_AGENCIA))
                        {
                            if (obj.dt.Rows.Count > 0) C_PFACTURADAS = obj.dt.Rows[0][2].ToString();
                            obj.dt.Dispose();
                        }

                        sql1 = "insert into facturadasagencias values('" + C_MARCA + "','" + C_AGENCIA + "','" + C_VFACTURADAS + "','" + C_PFACTURADAS + "')";
                        obj.mod_sql(sql1);

                    }  //end for  ciclo de agencias
                }   //end lista_agencias
                                
                return true;
            }
            catch (Exception er)
            {
                error = er.ToString();
                return false;
            }
        }

        public bool resumenrs7()
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                int i, j;
                DataTable tablas, aux;
                string sql1;
                string C_MARCA, C_AGENCIA, C_VFACTURADAS, C_PFACTURADAS, C_VENCUESTADAS, C_PENCUESTADAS, C_VPORCENTAJE, C_PPORCENTAJE, C_VALARMAS, C_PALARMAS;

                obj = new wfunciones1();
                tablas = new DataTable();
                tablas.Clear();
                tablas.Columns.Add("MARCA", typeof(string));
                tablas.Columns.Add("AGENCIA", typeof(string));
                tablas.Columns.Add("VFACTURADAS", typeof(string));
                tablas.Columns.Add("PFACTURADAS", typeof(string));
                tablas.Columns.Add("VENCUESTADAS", typeof(string));
                tablas.Columns.Add("PENCUESTADAS", typeof(string));
                tablas.Columns.Add("VPORCENTAJE", typeof(string));
                tablas.Columns.Add("PPORCENTAJE", typeof(string));
                tablas.Columns.Add("VALARMAS", typeof(string));
                tablas.Columns.Add("PALARMAS", typeof(string));

                //obtener agencias
                sql1 = "select * from lista_agencias with (nolock) order by marca,agencia";

                if (get_dato(sql1))
                {
                    aux = dt.Copy();
                    dt.Dispose();

                    for (i = 0; i < aux.Rows.Count; i++)
                    {
                        C_MARCA = aux.Rows[i][1].ToString();
                        C_AGENCIA = aux.Rows[i][2].ToString();
                        C_VFACTURADAS = "0"; C_PFACTURADAS = "0"; C_VENCUESTADAS = "0"; C_PENCUESTADAS = "0";
                        C_VPORCENTAJE = "0"; C_PPORCENTAJE = "0"; C_VALARMAS = "0"; C_PALARMAS = "0";

                        sql1 = "select * from facturadasagencias where MARCA='" + C_MARCA + "' and  AGENCIA='" + C_AGENCIA + "'";

                        if (get_dato(sql1))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                C_VFACTURADAS = dt.Rows[0][2].ToString();
                                C_PFACTURADAS = dt.Rows[0][3].ToString();
                            }

                            dt.Dispose();
                        }

                        //obtener encuestadas ventas
                        sql1 = "select CAST(SUBSTRING(fecha,4,2) AS INT) as mes,CAST(SUBSTRING(fecha,7,4) AS INT) as anio,COUNT(*) as encuestas from Tencuestas with (nolock) where marca='" + C_MARCA + "' and agencia='" + C_AGENCIA + "' and tipoenc='venta' and fecha like '%/" + DateTime.Now.ToString("MM").ToString() + "/" + DateTime.Now.ToString("yyyy").ToString() + "' group by CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT) order by CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT)";
                        C_VENCUESTADAS = obtener_dato(sql1);
                        dt.Dispose();
                        //obtener encuestadas postventas
                        sql1 = "select CAST(SUBSTRING(fecha,4,2) AS INT) as mes,CAST(SUBSTRING(fecha,7,4) AS INT) as anio,COUNT(*) as encuestas from Tencuestas with (nolock) where marca='" + C_MARCA + "' and agencia='" + C_AGENCIA + "' and tipoenc='postventa' and fecha like '%/" + DateTime.Now.ToString("MM").ToString() + "/" + DateTime.Now.ToString("yyyy").ToString() + "' group by CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT) order by CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT)";
                        C_PENCUESTADAS = obtener_dato(sql1);
                        dt.Dispose();

                        if (C_VFACTURADAS == "0") C_VPORCENTAJE = "0.00 %";
                        else C_VPORCENTAJE = ((float.Parse(C_VENCUESTADAS) / float.Parse(C_VFACTURADAS)) * 100).ToString("0.##") + " %";

                        if (C_PFACTURADAS == "0") C_PPORCENTAJE = "0.00 %";
                        else C_PPORCENTAJE = ((float.Parse(C_PENCUESTADAS) / float.Parse(C_PFACTURADAS)) * 100).ToString("0.##") + " %";

                        //obtener alarmas ventas
                        sql1 = "select CAST(SUBSTRING(fecha,4,2) AS INT) as mes,CAST(SUBSTRING(fecha,7,4) AS INT) as anio,COUNT(*) as alarmas from talarmas with (nolock) where marca='" + C_MARCA + "' and agencia='" + C_AGENCIA + "' and tipoenc='venta' and fecha like '%/" + DateTime.Now.ToString("MM").ToString() + "/" + DateTime.Now.ToString("yyyy").ToString() + "' group by CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT) order by CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT)";
                        C_VALARMAS = obtener_dato(sql1);
                        dt.Dispose();
                        //obtener alarmas postventas
                        sql1 = "select CAST(SUBSTRING(fecha,4,2) AS INT) as mes,CAST(SUBSTRING(fecha,7,4) AS INT) as anio,COUNT(*) as alarmas from talarmas with (nolock) where marca='" + C_MARCA + "' and agencia='" + C_AGENCIA + "' and tipoenc='postventa' and fecha like '%/" + DateTime.Now.ToString("MM").ToString() + "/" + DateTime.Now.ToString("yyyy").ToString() + "' group by CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT) order by CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT)";
                        C_PALARMAS = obtener_dato(sql1);
                        dt.Dispose();

                        tablas.Rows.Add(C_MARCA, C_AGENCIA, C_VFACTURADAS, C_PFACTURADAS, C_VENCUESTADAS, C_PENCUESTADAS, C_VPORCENTAJE, C_PPORCENTAJE, C_VALARMAS, C_PALARMAS);

                    }  //end for  ciclo de agencias
                }   //end lista_agencias

                lacadena = "";

                for (i = 0; i < tablas.Rows.Count; i++)
                {
                    for (j = 0; j < tablas.Columns.Count; j++) lacadena += tablas.Rows[i][j].ToString() + "||";

                    if (lacadena != "") lacadena = lacadena.Substring(0, (lacadena.Length - 2)) + "%&";
                }

                if (lacadena != "") lacadena = lacadena.Substring(0, (lacadena.Length - 2));

                return true;
            }
            catch (Exception er)
            {
                error = er.ToString();
                return false;
            }
        }


        private string obtener_dato(string sql)
        {
            if (get_dato(sql)) return dt.Rows[0][2].ToString();
            else return "0";

        }

        public bool tomadeautoslogin(String log, String pas)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Tlogin_tomadeautos with (nolock) where login='" + log + "' and pass='" + pas + "'"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool reportersalramas()
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                int lashoras;

                ////REPORTE DE ALARMAS
                String sql, anio;
                int i, j, k;
                DateTime hoy;
                StringBuilder builder = new StringBuilder();
                hoy = DateTime.Now;
                anio = hoy.ToString("yyyy");

                sql = "(select marca,agencia,('ALARMAS AL SUPERVISOR (SS)') nivel,CAST(SUBSTRING(fecha2,4,2) AS INT) as mes,CAST(SUBSTRING(fecha2,7,4) AS INT) as anio,count(*) as alertas from rs_status where ss!='' and CONVERT(SmallDateTime, fecha2, 103) between CONVERT(SmallDateTime, '01/01/" + anio + "', 103) and CONVERT(SmallDateTime, '31/12/" + anio + "', 103) group by CAST(SUBSTRING(fecha2,7,4) AS INT),CAST(SUBSTRING(fecha2,4,2) AS INT),marca,agencia union all select marca,agencia,('ALARMAS AL GERENTE GENERAL (SG)') nivel,CAST(SUBSTRING(fecha2,4,2) AS INT) as mes,CAST(SUBSTRING(fecha2,7,4) AS INT) as anio,count(*) as alertas from rs_status where sg!='' and CONVERT(SmallDateTime, fecha2, 103) between CONVERT(SmallDateTime, '01/01/" + anio + "', 103) and CONVERT(SmallDateTime, '31/12/" + anio + "', 103) group by CAST(SUBSTRING(fecha2,7,4) AS INT),CAST(SUBSTRING(fecha2,4,2) AS INT),marca,agencia union all select marca,agencia,('ALARMAS AL DIRECTOR (SD)') nivel,CAST(SUBSTRING(fecha2,4,2) AS INT) as mes,CAST(SUBSTRING(fecha2,7,4) AS INT) as anio,count(*) as alertas from rs_status where sd!='' and CONVERT(SmallDateTime, fecha2, 103) between CONVERT(SmallDateTime, '01/01/" + anio + "', 103) and CONVERT(SmallDateTime, '31/12/" + anio + "', 103) group by CAST(SUBSTRING(fecha2,7,4) AS INT),CAST(SUBSTRING(fecha2,4,2) AS INT),marca,agencia) order by marca,agencia,nivel,mes,anio";

                if (get_dato(sql))
                {
                    builder.Append("<br><br><center>ALERTAS RS<br>");
                    builder.Append("<table cellpadding='5' cellspacing='0' border='1'>");
                    builder.Append("<tr><td><b>MARCA</b></td><td><b>AGENCIA</b></td><td><b>NIVEL</b></td><td><b>MES</b></td><td><b>ANIO</b></td><td><b>ALERTAS</b></td></tr>");

                    for (j = 0; j < dt.Rows.Count; j++)
                    {
                        builder.Append("<tr>");
                        for (k = 0; k < dt.Columns.Count; k++) builder.Append("<td>" + dt.Rows[j][k].ToString() + "</td>");
                        builder.Append("</tr>");
                    }

                    builder.Append("</table></center><br><br><br>");
                }

                sql = "select marca,agencia,CAST(SUBSTRING(fecha,4,2) AS INT) as mes,CAST(SUBSTRING(fecha,7,4) AS INT) as anio,count(*) as alertas from Talarmas where tipoenc='venta' and CONVERT(SmallDateTime, fecha, 103) between CONVERT(SmallDateTime, '01/01/" + anio + "', 103) and CONVERT(SmallDateTime, '31/12/" + anio + "', 103) group by CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT),marca,agencia order by marca,agencia,mes,anio";

                if (get_dato(sql))
                {
                    builder.Append("<br><br><center>ALERTAS ENCUESTAS DE SALIDA AUTOS NUEVOS<br>");
                    builder.Append("<table cellpadding='5' cellspacing='0' border='1'>");
                    builder.Append("<tr><td><b>MARCA</b></td><td><b>AGENCIA</b></td><td><b>MES</b></td><td><b>ANIO</b></td><td><b>ALERTAS</b></td></tr>");

                    for (j = 0; j < dt.Rows.Count; j++)
                    {
                        builder.Append("<tr>");
                        for (k = 0; k < dt.Columns.Count; k++) builder.Append("<td>" + dt.Rows[j][k].ToString() + "</td>");
                        builder.Append("</tr>");
                    }

                    builder.Append("</table></center><br><br><br>");
                }

                sql = "select marca,agencia,CAST(SUBSTRING(fecha,4,2) AS INT) as mes,CAST(SUBSTRING(fecha,7,4) AS INT) as anio,count(*) as alertas from Talarmas where tipoenc='postventa' and CONVERT(SmallDateTime, fecha, 103) between CONVERT(SmallDateTime, '01/01/" + anio + "', 103) and CONVERT(SmallDateTime, '31/12/" + anio + "', 103) group by CAST(SUBSTRING(fecha,7,4) AS INT),CAST(SUBSTRING(fecha,4,2) AS INT),marca,agencia order by marca,agencia,mes,anio";

                if (get_dato(sql))
                {
                    builder.Append("<br><br><center>ALERTAS ENCUESTAS DE SALIDA SERVICIO<br>");
                    builder.Append("<table cellpadding='5' cellspacing='0' border='1'>");
                    builder.Append("<tr><td><b>MARCA</b></td><td><b>AGENCIA</b></td><td><b>MES</b></td><td><b>ANIO</b></td><td><b>ALERTAS</b></td></tr>");

                    for (j = 0; j < dt.Rows.Count; j++)
                    {
                        builder.Append("<tr>");
                        for (k = 0; k < dt.Columns.Count; k++) builder.Append("<td>" + dt.Rows[j][k].ToString() + "</td>");
                        builder.Append("</tr>");
                    }

                    builder.Append("</table></center><br><br><br>");
                }


                ////sendero1("alarma@carone.com.mx", "amoreno@carone.com.mx", "jorantes@carone.com,mx", "caronesite@gmail.com", "alertas RS y encuestas de salida", "", builder.ToString());
                ////sendero1("alarma@carone.com.mx", "amoreno@carone.com.mx", "jorantes@carone.com,mx", "caronesite@gmail.com", "alertas RS y encuestas de salida", builder.ToString(), builder.ToString());
                lacadena = sendero1("alarma@carone.com.mx", "amoreno@carone.com.mx", "jorantes@carone.com.mx", "caronesite@gmail.com", "alertas RS y encuestas de salida", builder.ToString(), builder.ToString());
                /////lacadena = builder.ToString();
                return true;
                ////END REPORTE DE ALARMAS                
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }


        private string sendero1(String from, String to, String cc, String bcc, String subject, String text, String html)
        {
            try
            {
                MailMessage correo1 = new MailMessage();
                SmtpClient smtp1 = new SmtpClient();
                correo1.From = new MailAddress(from);
                correo1.To.Add(to);
                correo1.CC.Add(cc);
                correo1.Bcc.Add(bcc);
                correo1.Subject = subject;
                AlternateView item = AlternateView.CreateAlternateViewFromString(text, null, "text/plain");
                AlternateView view2 = AlternateView.CreateAlternateViewFromString(html, null, "text/html");
                correo1.Body = "";
                correo1.IsBodyHtml = true;
                correo1.AlternateViews.Add(item);
                correo1.AlternateViews.Add(view2);
                correo1.Priority = MailPriority.Normal;
                smtp1.Host = "192.168.11.97";
                smtp1.Port = 25;
                smtp1.Credentials = new NetworkCredential(from, "ansinas");
                smtp1.Send(correo1);
                return "correo enviado";
            }
            catch (Exception er)
            {
                return er.ToString();
            }
        }


        public bool crear_png(String id_lead, String htmlcode, String folio, String lostelefonos)
        {
            String sql;
            int i;

            try
            {
                if (existe_archivo2(id_lead + ".png"))
                {//si existe
                    SMS_referencia.servicioSoapClient servicioweb2 = new SMS_referencia.servicioSoapClient();
                    string[] pedazos;
                    pedazos = Regex.Split(lostelefonos, ",");

                    for (i = 0; i < pedazos.Length; i++)
                    {
                        sql = "select * from whatsapplist with (nolock) where telefono='" + pedazos[i] + "'";
                        if (get_dato(sql))
                        {
                            servicioweb2.whatsapp_msg("+14155238886", "+521" + pedazos[i], "Se Alarmó id_lead= " + id_lead + ",folio= " + folio, "http://prospectos.carone.com.mx:8880/ws2/generados/" + id_lead + ".png");
                            System.Threading.Thread.Sleep(2000);
                        }
                    }
                }
                else
                {//no existe                    
                    WebsitesScreenshot.WebsitesScreenshot _Obj = new WebsitesScreenshot.WebsitesScreenshot();
                    WebsitesScreenshot.WebsitesScreenshot.Result _Result = _Obj.CaptureHTML(htmlcode);
                    if (_Result == WebsitesScreenshot.WebsitesScreenshot.Result.Captured)
                    {
                        _Obj.ImageFormat = WebsitesScreenshot.WebsitesScreenshot.ImageFormats.PNG;
                        //_Obj.ImageHeight = 800;
                        //_Obj.ImageWidth = 400;
                        //_Obj.PreserveAspectRatio = true;

                        //_Obj.BrowserHeight = 800;
                        //_Obj.BrowserWidth=400;
                        _Obj.SaveImage(System.Web.HttpContext.Current.Server.MapPath("~/generados/" + id_lead + ".png"));
                    }
                    _Obj.Dispose();

                    SMS_referencia.servicioSoapClient servicioweb2 = new SMS_referencia.servicioSoapClient();
                    string[] pedazos;
                    pedazos = Regex.Split(lostelefonos, ",");

                    for (i = 0; i < pedazos.Length; i++)
                    {
                        sql = "select * from whatsapplist with (nolock) where telefono='" + pedazos[i] + "'";
                        if (get_dato(sql))
                        {
                            servicioweb2.whatsapp_msg("+14155238886", "+521" + pedazos[i], "Se Alarmó id_lead= " + id_lead + ",folio= " + folio, "http://prospectos.carone.com.mx:8880/ws2/generados/" + id_lead + ".png");
                            System.Threading.Thread.Sleep(2000);
                        }
                    }

                }

                return true;
            }
            catch (Exception er)
            {
                this.error = "Error2: " + er.ToString();
                return false;
            }
        }

        private bool existe_archivo2(String cad)
        {
            return File.Exists(System.Web.HttpContext.Current.Server.MapPath("~/generados/" + cad));
        }


        public bool hayono(String cad)
        {
            return File.Exists(System.Web.HttpContext.Current.Server.MapPath("~/generados/" + cad));
        }


        public string nuevaconexion(string elmin, string eldns, string elsql)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                return obj.conectar3(elmin, eldns,elsql);
            }
            catch (Exception er)
            {
                return er.ToString();
            }
        }

        public bool cumpleanios(string ip)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                OracleConnection cnx3;
                int i;
                string gran_cadena = "";

                String cns3 = "Data Source=192.168.11." + ip + ":1521/SISTEMAS;User Id=CARONE;password=CARONE";
                cnx3 = new OracleConnection(cns3);
                cnx3.Open();
                OracleCommand cmd = new OracleCommand("SELECT CLIE_NOMBRE || ' ' || CLIE_APELLIDOPATERNO || ' ' || CLIE_APELLIDOMATERNO as NombreCliente,CLIE_EMAIL,FAAU_RFCFACTURA,CLIE_TELEFONO1 from VT_VLIBRODEVENTAS", cnx3);
                OracleDataAdapter Da = new OracleDataAdapter(cmd);
                dt = new DataTable();
                Da.Fill(dt);
                cnx3.Close();
                cnx3.Dispose();
                cnx3 = null;
                cmd.Dispose();
                cmd = null;
                Da.Dispose();
                Da = null;
                

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    gran_cadena += dt.Rows[i][0].ToString() + "||" + dt.Rows[i][1].ToString() + "||" + dt.Rows[i][2].ToString() + "||" + dt.Rows[i][3].ToString() + "||" + "%&"; 
                }

                lacadena = gran_cadena.Substring(0, (gran_cadena.Length - 2));
                return true;
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool participanteslogin(String log, String pas)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Tparticipantes with (nolock) where login='" + log + "' and pass='" + pas + "'"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool juntitajson(String idadmin, String idjuntita)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Tjuntas where idadmin='" + idadmin +"' and id=" + idjuntita))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.dt.Dispose();
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool leeracuerdos(String idadmin, String idjuntita)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select acuerdos from Tjuntas where idadmin='" + idadmin + "' and id=" + idjuntita))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.dt.Dispose();
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool leerpdetrabajo(String idadmin, String idjuntita)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Tpdetrabajo where idadmin='" + idadmin + "' and idjunta=" + idjuntita))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool chk_admin(String login, String pass)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Tadministradores with (nolock) where login='" + login + "' and pass='" + pass + "'"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool registrarasistencia(String idadminlog, String idadmin, String idjuntita, String idparticipante)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Tasistencia where idadminlog='" + idadminlog + "' and idadmin='" + idadmin + "' and idjuntita='" + idjuntita + "' and idparticipante='" + idparticipante + "'"))
                {
                    cad_JSON = "Error: La asistencia Ya ha sido registrado";  //dato repetido
                    this.error = "Error: La asistencia Ya ha sido registrado";
                    this.mensaje = "Error: La asistencia Ya ha sido registrado";
                    return false;
                }
                else
                {
                    DateTime hoy = DateTime.Now;

                    if (!obj.data("insert", "", "'" + idadminlog + "','" + idadmin + "','" + idjuntita + "','" + idparticipante + "','','" + hoy.ToString("dd") + "/" + hoy.ToString("MM") + "/" + hoy.ToString("yyyy") + "','" + hoy.ToString("HH") + ":" + hoy.ToString("mm") + "'", "Tasistencia", ""))
                    {
                        this.error = "Error: " + obj.error;
                        return false;
                    }

                    cad_JSON = "Dato Archivado";
                    return true;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool getasistencia(String idadmin, String idjuntita)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from Tasistencia with (nolock) where idjuntita = '" + idjuntita + "' and idadmin = '" + idadmin + "'"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public bool registrarfidelity(String resultado)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql("select * from fidelitytmp where id=" + resultado))
                {
                    String latabla,v1,v2,v6,v12,v4;

                    v1 = obj.dt.Rows[0][1].ToString();
                    v2 = obj.dt.Rows[0][2].ToString();
                    v6 = obj.dt.Rows[0][6].ToString();
                    v12 = obj.dt.Rows[0][12].ToString();
                    v4 = obj.dt.Rows[0][4].ToString();

                    if(obj.dt.Rows[0][15].ToString()=="")
                    {
                        if (obj.dt.Rows[0][1].ToString() == "NISSAN")
                        {
                            if ((obj.dt.Rows[0][2].ToString() == "SAN JERONIMO") || (obj.dt.Rows[0][2].ToString() == "SAN JERONIMO LAREDO") || (obj.dt.Rows[0][2].ToString() == "LAS AGUILAS") || (obj.dt.Rows[0][2].ToString() == "TLALPAN") || (obj.dt.Rows[0][2].ToString() == "TLALPAN LAREDO") || (obj.dt.Rows[0][2].ToString() == "LA JOYA") || (obj.dt.Rows[0][2].ToString() == "LA JOYA LAREDO") || (obj.dt.Rows[0][2].ToString() == "LA JOYA CROSSING")) latabla = "Tfuentes";
                            else latabla = "Tfuentesgolfo";
                        }
                        else latabla = "Tfuentes";

                        if (obj.data("insert", "", "'" + v1 + "','" + v2 + "','" + obj.dt.Rows[0][3] + "','" + v4 + "','" + obj.dt.Rows[0][5] + "','" + v6 + "','" + obj.dt.Rows[0][7] + "','" + obj.dt.Rows[0][8] + "','" + obj.dt.Rows[0][9] + "','" + obj.dt.Rows[0][10] + "','" + obj.dt.Rows[0][11] + "','" + v12 + "','" + obj.dt.Rows[0][13] + "','" + obj.dt.Rows[0][14] + "'", latabla, ""))
                        {
                            if (obj.show_sql("select MAX(id) from Tfuentes with (nolock)"))
                            {
                                if (obj.data("update", "", "idquest='" + obj.dt.Rows[0][0] + "'", "fidelitytmp", "id=" + resultado))
                                {
                                    //
                                }
                            }

                            if (latabla == "Tfuentes")
                            {
                                if (obj.data("insert", "", "'" + v1 + "','" + v2 + "','" + v6 + "','" + v12 + "','" + v4 + "','',''", "carta_check", ""))
                                {
                                    //
                                }
                            }

                            cad_JSON = "Dato Archivado";
                            return true;
                        }
                    }
                    else
                    {
                        cad_JSON = "Dato Archivado";
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public Boolean mudardatos()
        {
            wfunciones1 obj20 = new wfunciones1();
            DataTable aux5;
            int cont;
            cad_JSON = "";

            String sql = "select * from Treporterondin2 order by id";
            if (get_dato(sql))
            {
                aux5 = dt.Copy();
                dt.Dispose();

                for (cont = 0; cont < aux5.Rows.Count; cont++)
                {
                    cad_JSON += "\n\n\n\n" + "insert into Treporterondin (idvigilante,Marca,Agencia,registroNFC,prioridad,nombrefoto,reporte,fecha1,hora1,fecha2,hora2) values ('" + aux5.Rows[cont][1].ToString().Trim() + "','" + aux5.Rows[cont][2].ToString().Trim() + "','" + aux5.Rows[cont][3].ToString().Trim() + "','','" + aux5.Rows[cont][4].ToString().Trim() + "','" + aux5.Rows[cont][5].ToString().Trim() + "','" + aux5.Rows[cont][6].ToString().Trim() + "','" + aux5.Rows[cont][7].ToString().Trim() + "','" + aux5.Rows[cont][8].ToString().Trim() + "','','" + aux5.Rows[cont][9].ToString().Trim() + "','" + aux5.Rows[cont][10].ToString().Trim() + "')" + "\n\n";

                    if (obj20.mod_sql("insert into Treporterondin (idvigilante,Marca,Agencia,registroNFC,prioridad,nombrefoto,reporte,fecha1,hora1,fecha2,hora2) values ('" + aux5.Rows[cont][1].ToString().Trim() + "','" + aux5.Rows[cont][2].ToString().Trim() + "','" + aux5.Rows[cont][3].ToString().Trim() + "','','" + aux5.Rows[cont][4].ToString().Trim() + "','" + aux5.Rows[cont][5].ToString().Trim() + "','" + aux5.Rows[cont][6].ToString().Trim() + "','" + aux5.Rows[cont][7].ToString().Trim() + "','" + aux5.Rows[cont][8].ToString().Trim() + "','" + aux5.Rows[cont][9].ToString().Trim() + "','" + aux5.Rows[cont][10].ToString().Trim() + "')"))
                    {
                        //
                    }
                    else
                    {
                        error = cad_JSON + obj20.error;
                        return false;
                    }
                }    //  end for

                return true;

            }

            error = cad_JSON + obj20.error;
            return false;
        }

        public Boolean mudarparticipantes()
        {
            wfunciones1 obj20 = new wfunciones1();
            DataTable aux5;
            int cont;
            cad_JSON = "";

            String sql = "select marca,agencia,nombre,idadmin from Tparticipantes where trim(nombre) <> '' order by id";
            if (get_dato(sql))
            {
                aux5 = dt.Copy();
                dt.Dispose();

                for (cont = 0; cont < aux5.Rows.Count; cont++)
                {
                    cad_JSON += "\n\n\n\n" + "insert into Tparticipantes2 values ('" + aux5.Rows[cont][3].ToString().Trim() + "','" + aux5.Rows[cont][0].ToString().Trim() + "','" + aux5.Rows[cont][1].ToString().Trim() + "','','','" + aux5.Rows[cont][2].ToString().Trim() + "','','')" + "\n\n";

                    if (obj20.mod_sql("insert into Tparticipantes2 values ('" + aux5.Rows[cont][3].ToString().Trim() + "','" + aux5.Rows[cont][0].ToString().Trim() + "','" + aux5.Rows[cont][1].ToString().Trim() + "','','','" + aux5.Rows[cont][2].ToString().Trim() + "','','')"))
                    {
                        //
                    }
                    else
                    {
                        error = cad_JSON + obj20.error;
                        return false;
                    }
                }    //  end for aux5

                return true;

            }

            error = cad_JSON + obj20.error;
            return false;
        }











    }
}

