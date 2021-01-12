using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaDatos.ModeloEntity;


namespace CapaNegocio
{
    public class NegocioCatDepartamento
    {
        //agregar la referencia de dato para cat bodega
        DatosCatDepartamento varDepartamento = new DatosCatDepartamento();

        public bool metodoguardarNeg(ObjetoDepartamento datoCliente)
        {
            try
            {
                CAT_DEPARTAMENTO modeloTabla = new CAT_DEPARTAMENTO();

                modeloTabla.ID_DEPARTAMENTO = datoCliente.IdDepartamento;
                modeloTabla.NOMBRE_DEPARTAMENTO =datoCliente.NombreDepartamento;
                modeloTabla.ID_PAIS_DEPARTAMENTO = datoCliente.IdPais;  //le agregue esto debido a la relacion con el catalgo

                varDepartamento.metodoGuardar(modeloTabla);
                return true;
            }
            catch (Exception es)
            {
                return false;
            }
        }
        public ObjetoDepartamento metodoSeleccion(string nombreDepartamento)
        {
            var datoSeleccionado = varDepartamento.metodoSeleccion(nombreDepartamento);

            ObjetoDepartamento pasaCliente = new ObjetoDepartamento();
            pasaCliente.IdDepartamento = datoSeleccionado.ID_DEPARTAMENTO;
            pasaCliente.NombreDepartamento = datoSeleccionado.NOMBRE_DEPARTAMENTO;
            pasaCliente.IdPais = datoSeleccionado.ID_PAIS_DEPARTAMENTO;

            return pasaCliente;
        }
        public ObjetoDepartamento metodoSeleccion(int codigo)
        {
            var datoSeleccionado =  varDepartamento.metodoSeleccion(codigo);

            ObjetoDepartamento pasaCliente = new ObjetoDepartamento();
            pasaCliente.IdDepartamento = datoSeleccionado.ID_DEPARTAMENTO;
            pasaCliente.NombreDepartamento = datoSeleccionado.NOMBRE_DEPARTAMENTO;
            pasaCliente.IdPais = datoSeleccionado.ID_PAIS_DEPARTAMENTO;

            return pasaCliente;
        }
        public bool metodoBusca(string nombre)
        {
            return varDepartamento.metodoBusca(nombre);
        }
        //metodo para eliminar
        public bool metodoEliminar(int codigo)
        {
            try
            {
                varDepartamento.metodoEliminar(codigo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //metodo para mostrar los dados de la tabla   
        public List<ObjetoDepartamento> metodoMostrarListaDatos()
        {
            var datos = varDepartamento.metodoMostrarListaDatos();
            return datos;
        }

        //metodo para traer Ciudades
        public List<CAT_PAIS> traerPaises()
        {
            return varDepartamento.traerPaises();
        }
    }
}

