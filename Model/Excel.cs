using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using ypfbApplication.Controller;
using Controller;

namespace ypfbApplication.Model
{
    public class Excel
    {
        List<ParExcel_Columna> lstParExcelColumna = new List<ParExcel_Columna>();


        #region Barrido

        /// <summary>
        /// Ingreso de datos de la hojas de excel de GN, GNE, GNT, GLP, PCG, PRO
        /// </summary>
        /// <param name="dataSetExcel">data set con los datos recuperados</param>
        /// <param name="mes">mes a ser ingresado.</param>
        /// <param name="anio">anio a ser ingresado</param>
        /// <param name="lstParExcel">lista de para excel para recupera las columnas</param>
        public void RecorridoColumna(DataSet dataSetExcel, long mes, long anio, List<ParExcel> lstParExcel, string hojaexcelse)
        {
            List<Contrato_Campo> lstContratoCampo = new List<Contrato_Campo>();
            List<Titular_Contrato> lstTitularContrato = new List<Titular_Contrato>();
            List<Campo> lstCampo = new List<Campo>();
            List<Calculo> lstCalculo = new List<Calculo>();

            Calculo_Variable AddCalculo_Variable = new Calculo_Variable();

            Calculo_VariableController objCalculoVariableController = new Calculo_VariableController();
            CalculoController objCalculoController = new CalculoController();

            ParExcel_ColumnaController parExcel_ColummnaController = new ParExcel_ColumnaController();

            Contrato_Campo[] contratoCampoValidador = null;

            lstParExcelColumna = parExcel_ColummnaController.loadBypex_id(lstParExcel[0].Pex_id);
            long Cal_id = 0;
            int q = 0;
            int columna = recuperarValorNumeralColumna(lstParExcelColumna, q);
            int f = (int)lstParExcelColumna[0].Pec_fila - 1;
            int parexcel1 = 0;

            decimal rounded = 0;

            for (int fila = f; fila < dataSetExcel.Tables[0].Rows.Count; fila++)
            {
                if ((dataSetExcel.Tables[0].Rows[fila][columna].ToString() != ""))
                {
                    lstTitularContrato = Titular_SinonimoController.ExisteTitularSinonimo(dataSetExcel.Tables[0].Rows[fila][columna].ToString().Trim());
                    if (lstTitularContrato.Count != 0)
                    {
                        q++;
                        columna = recuperarValorNumeralColumna(lstParExcelColumna, q);
                        parexcel1++;
                        if (columna > dataSetExcel.Tables[0].Columns.Count)
                        {
                            throw new Exception("No se encontro la columna: " + lstParExcelColumna[q].Pec_Columna.ToString() + ". Por favor revise la hoja excel " + hojaexcelse.ToString());
                        }
                    }
                    lstCampo = new List<Campo>();
                    for (int c = fila; c < dataSetExcel.Tables[0].Rows.Count; c++)
                    {
                        if (dataSetExcel.Tables[0].Rows[c][columna].ToString().Trim() != "" && dataSetExcel.Tables[0].Rows[c][columna].ToString().Trim().StartsWith("TOTAL") == false)
                        {
                            lstCampo.Add(Campo_SinonimoController.ExisteCampoContrato(dataSetExcel.Tables[0].Rows[c][columna].ToString().Trim().Replace("*", "")));

                        }
                        else if (dataSetExcel.Tables[0].Rows[c][columna].ToString().Trim().StartsWith("TOTAL"))
                        {
                            q++;
                            columna = recuperarValorNumeralColumna(lstParExcelColumna, q);
                            //fila = fila - 1;
                            parexcel1++;
                            if (columna >dataSetExcel.Tables[0].Columns.Count)
                            {
                                throw new Exception("No se encontro la columna: " + lstParExcelColumna[q].Pec_Columna.ToString()+". Por favor revise la hoja excel " + hojaexcelse.ToString());
                            }
                            break;
                        }
                        if (lstTitularContrato.Count > 0)
                        {
                            contratoCampoValidador = new Contrato_Campo[lstCampo.Count];
                            for (int t = 0; t < lstTitularContrato.Count; t++)
                            {
                                lstContratoCampo = ContratoCampoController.GetListContratoCamposPorContrato(lstTitularContrato[t].Ctt_id);
                                for (int contContrato = 0; contContrato < lstContratoCampo.Count; contContrato++)
                                {
                                    for (int c1 = 0; c1 < lstCampo.Count; c1++)
                                    {
                                        if (lstCampo[c1].Cam_nombre == lstContratoCampo[contContrato].Cam_nombre)
                                        {
                                            contratoCampoValidador[c1] = lstContratoCampo[contContrato];
                                        }
                                    }
                                }
                            }
                        }
                    }
                    int comienza = columna;
                    int ComienzaQ = q;
                    foreach (Contrato_Campo item in contratoCampoValidador)
                    {
                        lstCalculo = objCalculoController.Validar(item.Ctt_id, mes, anio, lstParExcel[0].Tcl_id);
                        if (lstCalculo.Count > 0)
                        {
                            if (item.Ctt_id != lstCalculo[0].Ctt_id)
                            {
                                List<Calculo> lstAddCalculo = new List<Calculo>();
                                Calculo AddCaldulo = new Calculo();
                                AddCaldulo.Cal_id = 0;
                                AddCaldulo.Ctt_id = item.Ctt_id;
                                AddCaldulo.Cal_fecha = DateTime.Now;
                                AddCaldulo.Ani_id = anio;
                                AddCaldulo.Mes_id = anio;
                                AddCaldulo.Mon_id = 2;
                                AddCaldulo.Cal_valor = 0;
                                AddCaldulo.Cal_valorajustado = 0;
                                AddCaldulo.Tcl_id = lstParExcel[0].Tcl_id;
                                AddCaldulo.Cal_estado = 1;
                                AddCaldulo.Cal_depacuma = 0;
                                AddCaldulo.Cal_acugantit = 0;
                                AddCaldulo.Cal_invacuma = 0;
                                AddCaldulo.Cal_acuimptit = 0;
                                lstAddCalculo.Add(AddCaldulo);
                                Cal_id = objCalculoController.save(lstAddCalculo);
                            }
                            else
                            {
                                Cal_id = lstCalculo[0].Cal_id;
                            }
                        }
                        if (lstCalculo.Count == 0)
                        {
                            List<Calculo> lstAddCalculo = new List<Calculo>();
                            Calculo AddCaldulo = new Calculo();
                            AddCaldulo.Cal_id = 0;
                            AddCaldulo.Ctt_id = item.Ctt_id;
                            AddCaldulo.Cal_fecha = DateTime.Now;
                            AddCaldulo.Ani_id = anio;
                            AddCaldulo.Mes_id = mes;
                            AddCaldulo.Mon_id = 2;
                            AddCaldulo.Cal_valor = 0;
                            AddCaldulo.Cal_valorajustado = 0;
                            AddCaldulo.Tcl_id = lstParExcel[0].Tcl_id;
                            AddCaldulo.Cal_estado = 1;
                            AddCaldulo.Cal_depacuma = 0;
                            AddCaldulo.Cal_acugantit = 0;
                            AddCaldulo.Cal_invacuma = 0;
                            AddCaldulo.Cal_acuimptit = 0;
                            lstAddCalculo.Add(AddCaldulo);
                            Cal_id = objCalculoController.save(lstAddCalculo);
                        }
                        decimal volumen = 0;
                        long id = 0;
                        bool flag = false;
                        decimal volumenSeca_60 = 0;
                        for (int p = q; p < lstParExcelColumna.Count; p++)
                        {

                            if ((item.Ctt_id > 0) || (Cal_id > 0))
                            {

                                if (!dataSetExcel.Tables[0].Rows[fila][columna].ToString().Trim().ToLower().StartsWith("total"))
                                {
                                    List<Calculo_Variable> lstCalculoVariable = new List<Calculo_Variable>();
                                    AddCalculo_Variable.Cav_id = 0;
                                    AddCalculo_Variable.Cal_id = Cal_id;
                                    AddCalculo_Variable.Cam_id = item.Cam_id;
                                    AddCalculo_Variable.Pro_id = lstParExcel[0].Pro_id;
                                    AddCalculo_Variable.Mer_id = lstParExcelColumna[p].Mer_id;
                                    AddCalculo_Variable.Var_id = lstParExcelColumna[p].Var_id;
                                    AddCalculo_Variable.Umd_id = 0;
                                    AddCalculo_Variable.Mon_id = 0;
                                    if (dataSetExcel.Tables[0].Rows[fila][columna].ToString().Trim() != "")
                                    {
                                        if (dataSetExcel.Tables[0].Rows[fila][columna].ToString().Trim() != "-")
                                        {
                                            if (hojaexcelse == "GN")
                                            {
                                                if (lstParExcelColumna[p].Pec_Convercion == 0)
                                                {
                                                    if (lstParExcelColumna[p].Pec_iva == false)
                                                    {
                                                        decimal valor = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[fila][columna].ToString());
                                                        decimal valorsinIva = decimal.Round(valor, 8);
                                                        AddCalculo_Variable.Cav_valor = ((valorsinIva * Convert.ToDecimal(0.87)));
                                                        volumen = decimal.Round(AddCalculo_Variable.Cav_valor, 8);
                                                    }
                                                    else
                                                    {
                                                        decimal valor = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[fila][columna].ToString());
                                                        decimal valorConIva = decimal.Round(valor, 8);
                                                        AddCalculo_Variable.Cav_valor = ((valorConIva));
                                                        volumen = decimal.Round(AddCalculo_Variable.Cav_valor, 8);
                                                    }
                                                }

                                                else if (lstParExcelColumna[p].Pec_Convercion == 1)
                                                {

                                                    if (lstParExcelColumna[p].Pec_iva == false)
                                                    {

                                                        decimal valor = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[fila][columna].ToString());
                                                        decimal valorConIva = decimal.Round(valor, 8);
                                                        decimal valorSinIva = valorConIva * Convert.ToDecimal(0.87);
                                                        volumen = volumen / 1000;
                                                        decimal pc = 0;
                                                        if (volumen != 0)
                                                            pc = valorSinIva / volumen;
                                                        else
                                                            pc = 0;
                                                        decimal baseSeca = pc / Convert.ToDecimal(0.9769);
                                                        decimal BaseSeca_60 = Convert.ToDecimal(1.01539) * baseSeca;
                                                        volumenSeca_60 = (volumen / Convert.ToDecimal(1.01539));
                                                        decimal baseSaturada_60 = Convert.ToDecimal(0.9826) * BaseSeca_60;
                                                        decimal total = volumenSeca_60 * baseSaturada_60;

                                                        AddCalculo_Variable.Cav_valor = decimal.Round(total, 8);

                                                        flag = true;

                                                    }
                                                    else
                                                    {
                                                        decimal valorConIva = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[fila][columna].ToString());
                                                        decimal pc = 0;
                                                        volumen = volumen / 1000;
                                                        if (volumen != 0)
                                                            pc = valorConIva / volumen;
                                                        else
                                                            pc = 0;
                                                        decimal baseSeca = pc / Convert.ToDecimal(0.9769);
                                                        decimal BaseSeca_60 = Convert.ToDecimal(1.01539) * baseSeca;
                                                        decimal baseSaturada_60 = Convert.ToDecimal(0.9826) * BaseSeca_60;

                                                        volumenSeca_60 = (volumen / Convert.ToDecimal(1.01539));

                                                        decimal total = volumenSeca_60 * baseSaturada_60;

                                                        AddCalculo_Variable.Cav_valor = decimal.Round(total, 8);

                                                        flag = true;
                                                    }
                                                }
                                                else
                                                {
                                                    if (lstParExcelColumna[p].Pec_iva == false)
                                                    {
                                                        decimal valorConIva = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[fila][columna].ToString());
                                                        decimal valorSinIva = valorConIva * Convert.ToDecimal(0.87);
                                                        decimal baseSaturada_60 = Convert.ToDecimal(0.9826) * valorSinIva;
                                                        AddCalculo_Variable.Cav_valor = decimal.Round(baseSaturada_60, 8);
                                                    }
                                                    else
                                                    {
                                                        decimal valorConIva = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[fila][columna].ToString());
                                                        decimal baseSaturada_60 = Convert.ToDecimal(0.9826) * valorConIva;
                                                        AddCalculo_Variable.Cav_valor = decimal.Round(baseSaturada_60, 8);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (lstParExcelColumna[p].Pec_iva == false)
                                                {
                                                    decimal valorConIva = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[fila][columna].ToString());
                                                    AddCalculo_Variable.Cav_valor = decimal.Round((valorConIva * Convert.ToDecimal(0.87)), 8);
                                                }
                                                else
                                                {
                                                    decimal valorConIva = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[fila][columna].ToString());
                                                    AddCalculo_Variable.Cav_valor = decimal.Round((valorConIva), 8);
                                                }
                                            }

                                        }
                                        else
                                            AddCalculo_Variable.Cav_valor = 0;
                                    }
                                    else
                                        AddCalculo_Variable.Cav_valor = 0;
                                    AddCalculo_Variable.Cav_estado = 1;
                                    AddCalculo_Variable.Cav_tipo = "Y";
                                    AddCalculo_Variable.Pex_id = lstParExcel[0].Pex_id;
                                    lstCalculoVariable.Add(AddCalculo_Variable);
                                    id = objCalculoVariableController.save(lstCalculoVariable);
                                    //if (flag)
                                    //{
                                    //    objCalculoVariableController.updateCav_Valor(id, volumenSeca_60);
                                    //    id = 0;
                                    //    flag = false;
                                    //    volumenSeca_60 = 0;
                                    //    id = objCalculoVariableController.save(lstCalculoVariable);
                                    //}
                                    //else
                                    ////{
                                    //    id = objCalculoVariableController.save(lstCalculoVariable);
                                    //}

                                }
                            }
                            else
                            {
                                if (item.Cam_id != 0)
                                    throw new Exception("Error en el id del campo. " + item.Cam_id + " " + item.Cam_nombre);
                                if (item.Ctt_id != 0)
                                    throw new Exception("Error en el id del contrato. " + item.Ctt_id);
                            }
                            if (q < lstParExcelColumna.Count - 1)
                            {
                                q++;                                
                                columna = recuperarValorNumeralColumna(lstParExcelColumna, q);
                                if (columna > dataSetExcel.Tables[0].Columns.Count)
                                {
                                    throw new Exception("No se encontro la columna: " + lstParExcelColumna[q].Pec_Columna.ToString()+". Por favor revise la hoja excel " + hojaexcelse.ToString());
                                }
                            }
                        }
                        columna = comienza;
                        q = ComienzaQ;
                        columna = recuperarValorNumeralColumna(lstParExcelColumna, q);
                        fila = fila + 1;
                    }
                }
                q = 0;
                columna = recuperarValorNumeralColumna(lstParExcelColumna, q);
                parexcel1 = 0;
            }
        }

        /// <summary>
        /// Ingreso de los datos como ser Titular, inversion y costo
        /// </summary>
        /// <param name="dataSetExcel">datos a ser cagados</param>
        /// <param name="mes">mes a almacenar</param>
        /// <param name="anio">anio a ser almacenado</param>
        /// <param name="lstParExcel">cavesera de la configuracion de la excel</param>
        /// <param name="ctt_id">Contrato a ser guardado</param>
        public void RecorridoFila(DataSet dataSetExcel, long mes, long anio, List<ParExcel> lstParExcel, long ctt_id, string hojaexcelse)
        {
            List<Titular_Contrato> lstTitularContrato = new List<Titular_Contrato>();
            List<Calculo> lstCalculo = new List<Calculo>();

            Calculo_VariableController objCalculoVariableController = new Calculo_VariableController();
            CalculoController objCalculoController = new CalculoController();
            ParExcel_ColumnaController parExcel_ColummnaController = new ParExcel_ColumnaController();

            lstParExcelColumna = parExcel_ColummnaController.loadBypex_id(lstParExcel[0].Pex_id);

            long Cal_id = 0;
            int q = 0;
            int i = recuperarValorNumeralColumna(lstParExcelColumna, q);
            int fila = (int)lstParExcelColumna[0].Pec_fila - 1;
            if (i > dataSetExcel.Tables[0].Columns.Count)
            {
                throw new Exception("No se encontro la columna: " + lstParExcelColumna[q].Pec_Columna.ToString() + ". Por favor revise la hoja excel " + hojaexcelse.ToString());
            }
            while (lstParExcelColumna.Count > q)
            {
                lstCalculo = objCalculoController.Validar(ctt_id, mes, anio, lstParExcel[0].Tcl_id);
                if (lstCalculo.Count == 0)
                {
                    
                    List<Calculo> lstAddCalculo = new List<Calculo>();
                    Calculo AddCaldulo = new Calculo();
                    AddCaldulo.Cal_id = 0;
                    AddCaldulo.Ctt_id = ctt_id;
                    AddCaldulo.Cal_fecha = DateTime.Now;
                    AddCaldulo.Ani_id = anio;
                    AddCaldulo.Mes_id = mes;
                    AddCaldulo.Mon_id = 2;
                    AddCaldulo.Cal_valor = 0;
                    AddCaldulo.Cal_valorajustado = 0;
                    AddCaldulo.Tcl_id = lstParExcel[0].Tcl_id;
                    AddCaldulo.Cal_estado = 1;
                    AddCaldulo.Cal_depacuma = 0;
                    AddCaldulo.Cal_acugantit = 0;
                    AddCaldulo.Cal_invacuma = 0;
                    AddCaldulo.Cal_acuimptit = 0;
                    lstAddCalculo.Add(AddCaldulo);
                    Cal_id = objCalculoController.save(lstAddCalculo);
                }
                else
                {

                    if ((lstCalculo[0].Ani_id == anio) && (lstCalculo[0].Mes_id == mes))
                    {
                        Cal_id = lstCalculo[0].Cal_id;
                    }
                }
                List<Calculo_Variable> lstCalculoVariable = new List<Calculo_Variable>();
                Calculo_Variable AddCalculo_Variable = new Calculo_Variable();
                AddCalculo_Variable.Cav_id = 0;
                AddCalculo_Variable.Cal_id = Cal_id;
                AddCalculo_Variable.Cam_id = 0;
                AddCalculo_Variable.Pro_id = lstParExcel[0].Pro_id;
                AddCalculo_Variable.Mer_id = lstParExcelColumna[q].Mer_id;
                AddCalculo_Variable.Var_id = lstParExcelColumna[q].Var_id;
                AddCalculo_Variable.Umd_id = 0;
                AddCalculo_Variable.Mon_id = 0;
                if (dataSetExcel.Tables[0].Rows[fila][i].ToString().Trim() != "")
                {
                    if (dataSetExcel.Tables[0].Rows[fila][i].ToString().Trim() != "-")
                        if (lstParExcelColumna[q].Pec_iva == false)
                        {
                            decimal valorsinIva = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[fila][i].ToString());
                            AddCalculo_Variable.Cav_valor = decimal.Round((valorsinIva * Convert.ToDecimal(0.87)), 8);
                        }
                        else
                        {

                            if (dataSetExcel.Tables[0].Rows[fila][i].ToString().EndsWith("%"))
                            {
                                if (lstParExcelColumna[q].Var_id == 123)
                                {
                                    string porcentaje = dataSetExcel.Tables[0].Rows[fila][i].ToString().Replace("%", "");
                                    //decimal porciento = Convert.ToDecimal(porcentaje) / 100;
                                    decimal porciento = Convert.ToDecimal(porcentaje);
                                    AddCalculo_Variable.Cav_valor = decimal.Round(porciento, 8);
                                }
                                else
                                {
                                    string porcentaje = dataSetExcel.Tables[0].Rows[fila][i].ToString().Replace("%", "");
                                    decimal porciento = Convert.ToDecimal(porcentaje) / 100;
                                    //decimal porciento = Convert.ToDecimal(porcentaje);
                                    AddCalculo_Variable.Cav_valor = decimal.Round(porciento, 8);
                                }
                            }
                            else
                            {
                                AddCalculo_Variable.Cav_valor = decimal.Round(Convert.ToDecimal(dataSetExcel.Tables[0].Rows[fila][i].ToString()), 8);
                            }
                        }
                    else
                        AddCalculo_Variable.Cav_valor = 0;
                }
                else
                    AddCalculo_Variable.Cav_valor = 0;
                AddCalculo_Variable.Cav_estado = 1;
                if (lstParExcel[0].Pxt_codigo == "TIT")
                    AddCalculo_Variable.Cav_tipo = "T";
                else
                    AddCalculo_Variable.Cav_tipo = "Y";
                AddCalculo_Variable.Pex_id = lstParExcel[0].Pex_id;
                lstCalculoVariable.Add(AddCalculo_Variable);
                objCalculoVariableController.save(lstCalculoVariable);
                q++;
                if (lstParExcelColumna.Count > q)
                {
                    i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                    fila = (int)lstParExcelColumna[q].Pec_fila - 1;
                    if (i > dataSetExcel.Tables[0].Columns.Count)
                    {
                        throw new Exception("No se encontro la columna: " + lstParExcelColumna[q].Pec_Columna.ToString() + ". Por favor revise la hoja excel " + hojaexcelse.ToString());
                    }
                }
            }

        }

        /// <summary>
        /// Recorrido de la hoja excel de certificaciones
        /// </summary>
        /// <param name="dataSetExcel">Datos a ser ingresados</param>
        /// <param name="lstParExcel">lista de la configuracion de la excel</param>
        public void RecorridoNormal(DataSet dataSetExcel, List<ParExcel> lstParExcel, string hojaexcelse)
        {
            List<Titular_Contrato> lstTitularContrato = new List<Titular_Contrato>();
            List<Campo> lstCampo = new List<Campo>();
            List<Contrato_Campo> lstContratoCampo = new List<Contrato_Campo>();
            List<Calculo> lstCalculo = null;
            List<Calculo_Variable> lstCalculo_Variable = null;

            CalculoController CalculoController = new CalculoController();
            Calculo_VariableController objCalculoVariableController = new Calculo_VariableController();
            ParExcel_ColumnaController parExcel_ColummnaController = new ParExcel_ColumnaController();

            Contrato_Campo[] contratoCampoValidador = null;

            Campo campo;

            lstParExcelColumna = parExcel_ColummnaController.loadBypex_id(lstParExcel[0].Pex_id);

            long Cal_id = 0;
            int q = 0;
            int i = recuperarValorNumeralColumna(lstParExcelColumna, q);
            int fila = (int)lstParExcelColumna[0].Pec_fila - 1;
            int parexcel1 = 0;
            int mesInt = 0;
            int anio = 0;

            string mes;
            string titular;
            for (int f = fila; f < dataSetExcel.Tables[0].Rows.Count; f++)
            {
                if (dataSetExcel.Tables[0].Rows[f][i].ToString().Trim() != "")
                {
                    anio = int.Parse(dataSetExcel.Tables[0].Rows[f][i].ToString().Trim().ToUpper());
                    parexcel1++;
                    q++;
                    i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                    if (i > dataSetExcel.Tables[0].Columns.Count)
                    {
                        throw new Exception("No se encontro la columna: " + lstParExcelColumna[q].Pec_Columna.ToString() + ". Por favor revise la hoja excel " + hojaexcelse.ToString());
                    }
                    mes = dataSetExcel.Tables[0].Rows[f][i].ToString().ToUpper().Trim();
                    parexcel1++;

                    switch (mes)
                    {
                        case "ENERO":
                            mesInt = 1;
                            break;
                        case "FEBRERO":
                            mesInt = 2;
                            break;
                        case "MARZO":
                            mesInt = 3;
                            break;
                        case "ABRIL":
                            mesInt = 4;
                            break;
                        case "MAYO":
                            mesInt = 5;
                            break;
                        case "JUNIO":
                            mesInt = 6;
                            break;
                        case "JULIO":
                            mesInt = 7;
                            break;
                        case "AGOSTO":
                            mesInt = 8;
                            break;
                        case "SEPTIEMBRE":
                            mesInt = 9;
                            break;
                        case "OCTUBRE":
                            mesInt = 10;
                            break;
                        case "NOVIEMBRE":
                            mesInt = 11;
                            break;
                        case "DICIEMBRE":
                            mesInt = 12;
                            break;
                    }
                    q++;
                    i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                    if (i > dataSetExcel.Tables[0].Columns.Count)
                    {
                        throw new Exception("No se encontro la columna: " + lstParExcelColumna[q].Pec_Columna.ToString() + ". Por favor revise la hoja excel " + hojaexcelse.ToString());
                    }
                    titular = dataSetExcel.Tables[0].Rows[f][i].ToString();
                    parexcel1++;
                    lstTitularContrato = Titular_SinonimoController.ExisteTitularSinonimo(titular.Trim().ToUpper());
                    q++;
                    i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                    campo = Campo_SinonimoController.ExisteCampoContrato(dataSetExcel.Tables[0].Rows[f][i].ToString().Trim().ToUpper());
                    contratoCampoValidador = new Contrato_Campo[1];
                    for (int l = 0; l < lstTitularContrato.Count; l++)
                    {
                        lstContratoCampo = ContratoCampoController.GetListContratoCamposPorContrato(lstTitularContrato[l].Ctt_id);
                        if (lstContratoCampo.Count > 0)
                        {
                            for (int cont = 0; cont < lstContratoCampo.Count; cont++)
                            {
                                if (campo.Cam_nombre == lstContratoCampo[cont].Cam_nombre)
                                {
                                    contratoCampoValidador[0] = lstContratoCampo[cont];
                                    cont = lstContratoCampo.Count;
                                    l = lstTitularContrato.Count;
                                }
                            }
                        }
                    }
                    parexcel1++;
                    q++;
                    i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                    if (i > dataSetExcel.Tables[0].Columns.Count)
                    {
                        throw new Exception("No se encontro la columna: " + lstParExcelColumna[q].Pec_Columna.ToString() + ". Por favor revise la hoja excel " + hojaexcelse.ToString());
                    }
                    if (contratoCampoValidador != null)
                    {
                        lstCalculo = CalculoController.Validar(contratoCampoValidador[0].Ctt_id, mesInt, anio, lstParExcel[0].Tcl_id);
                        CalculoController objCalculoController = new CalculoController();
                        if (lstCalculo.Count == 0)
                        {
                            List<Calculo> lstAddCalculo = new List<Calculo>();
                            Calculo AddCaldulo = new Calculo();
                            AddCaldulo.Cal_id = 0;
                            AddCaldulo.Ctt_id = contratoCampoValidador[0].Ctt_id;
                            AddCaldulo.Cal_fecha = DateTime.Now;
                            AddCaldulo.Ani_id = anio;
                            AddCaldulo.Mes_id = mesInt;
                            AddCaldulo.Mon_id = 2;
                            AddCaldulo.Cal_valor = 0;
                            AddCaldulo.Cal_valorajustado = 0;
                            AddCaldulo.Tcl_id = lstParExcel[0].Tcl_id;
                            AddCaldulo.Cal_estado = 1;
                            AddCaldulo.Cal_depacuma = 0;
                            AddCaldulo.Cal_acugantit = 0;
                            AddCaldulo.Cal_invacuma = 0;
                            AddCaldulo.Cal_acuimptit = 0;
                            lstAddCalculo.Add(AddCaldulo);
                            Cal_id = objCalculoController.save(lstAddCalculo);
                        }
                        else
                        {
                            if ((lstCalculo[0].Ani_id == anio && lstCalculo[0].Mes_id == mesInt) && (lstCalculo[0].Ctt_id == contratoCampoValidador[0].Ctt_id))
                            {
                                Cal_id = lstCalculo[0].Cal_id;
                            }

                        }
                        for (int c = q; c < lstParExcelColumna.Count; c++)
                        {
                            if ((contratoCampoValidador[0].Ctt_id > 0) || (Cal_id > 0))
                            {
                                if (!dataSetExcel.Tables[0].Rows[f][i].ToString().Trim().ToLower().StartsWith("total"))
                                {
                                    lstCalculo_Variable = new List<Calculo_Variable>();
                                    Calculo_Variable AddCalculo_Variable = new Calculo_Variable();
                                    AddCalculo_Variable.Cav_id = 0;
                                    AddCalculo_Variable.Cal_id = Cal_id;
                                    AddCalculo_Variable.Cam_id = contratoCampoValidador[0].Cam_id;
                                    AddCalculo_Variable.Pro_id = lstParExcel[0].Pro_id;
                                    AddCalculo_Variable.Mer_id = lstParExcelColumna[c].Mer_id;
                                    AddCalculo_Variable.Var_id = lstParExcelColumna[c].Var_id;
                                    AddCalculo_Variable.Umd_id = lstParExcelColumna[c].Umd_id;
                                    AddCalculo_Variable.Mon_id = 0;
                                    if (dataSetExcel.Tables[0].Rows[f][i].ToString().Trim() != "")
                                        if (dataSetExcel.Tables[0].Rows[f][i].ToString().Trim() != "-")
                                            if (lstParExcelColumna[c].Pec_iva == false)
                                            {
                                                decimal valorsinIva = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[f][i].ToString());
                                                AddCalculo_Variable.Cav_valor = decimal.Round(valorsinIva * Convert.ToDecimal(0.87), 8);
                                            }
                                            else
                                            {
                                                AddCalculo_Variable.Cav_valor = decimal.Round(Convert.ToDecimal(dataSetExcel.Tables[0].Rows[f][i].ToString()), 8);
                                            }
                                        else
                                            AddCalculo_Variable.Cav_valor = 0;
                                    else
                                        AddCalculo_Variable.Cav_valor = 0;
                                    AddCalculo_Variable.Cav_estado = 1;
                                    AddCalculo_Variable.Cav_tipo = "Y";
                                    AddCalculo_Variable.Pex_id = lstParExcel[0].Pex_id;
                                    lstCalculo_Variable.Add(AddCalculo_Variable);
                                    objCalculoVariableController.save(lstCalculo_Variable);
                                }
                            }
                            else
                            {
                                if (contratoCampoValidador[0].Cam_id != 0)
                                    throw new Exception("Error en el id del campo. " + contratoCampoValidador[0].Cam_nombre + " " + contratoCampoValidador[0].Cam_nombre + " que esta en la hoja excel: " + hojaexcelse);
                                if (contratoCampoValidador[0].Ctt_id != 0)
                                    throw new Exception("Error en el id del contrato. " + contratoCampoValidador[0].Ctt_id + " que esta en la hoja excel: " + hojaexcelse);
                            }
                            if (q < lstParExcelColumna.Count - 1)
                            {
                                q++;
                                i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                                if (i > dataSetExcel.Tables[0].Columns.Count)
                                {
                                    throw new Exception("No se encontro la columna: " + lstParExcelColumna[q].Pec_Columna.ToString() + ". Por favor revise la hoja excel " + hojaexcelse.ToString());
                                }
                            }
                        }
                    }
                    q = 0;
                    parexcel1 = 0;
                    i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                }
            }
        }

        /// <summary>
        /// registro de los datos de IDH Y REGALIAS
        /// </summary>
        /// <param name="dataSetExcel">Datos a ser ingresados</param>
        /// <param name="lstParExcel">lista de la configuracion de la hoja excel</param>
        public void AuxiliarIDHyREG(DataSet dataSetExcel, List<ParExcel> lstParExcel, string hojaexcelse)
        {
            Contrato objContrato = new Contrato();
            Campo objCampo = new Campo();

            ParExcel_ColumnaController parExcel_ColummnaController = new ParExcel_ColumnaController();

            lstParExcelColumna = parExcel_ColummnaController.loadBypex_id(lstParExcel[0].Pex_id);

            int fila = (int)lstParExcelColumna[0].Pec_fila - 1;
            int parexcel1 = 0;
            int anio = 0;
            int mesInt = 0;
            string mes;
            int q = 0;
            int i = recuperarValorNumeralColumna(lstParExcelColumna, q);

            for (int f = fila; f < dataSetExcel.Tables[0].Rows.Count; f++)
            {
                if (dataSetExcel.Tables[0].Rows[f][i].ToString().Trim() != "")
                {
                    anio = int.Parse(dataSetExcel.Tables[0].Rows[f][i].ToString().ToUpper().Trim());
                    parexcel1++;
                    q++;
                    i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                    if (i > dataSetExcel.Tables[0].Columns.Count)
                    {
                        throw new Exception("No se encontro la columna: " + lstParExcelColumna[q].Pec_Columna.ToString() + ". Por favor revise la hoja excel " + hojaexcelse.ToString());
                    }
                }
                if (dataSetExcel.Tables[0].Rows[f][i].ToString().Trim() != "")
                {
                    mes = dataSetExcel.Tables[0].Rows[f][i].ToString().ToUpper().Trim();
                    parexcel1++;

                    switch (mes)
                    {
                        case "ENERO":
                            mesInt = 1;
                            break;
                        case "FEBRERO":
                            mesInt = 2;
                            break;
                        case "MARZO":
                            mesInt = 3;
                            break;
                        case "ABRIL":
                            mesInt = 4;
                            break;
                        case "MAYO":
                            mesInt = 5;
                            break;
                        case "JUNIO":
                            mesInt = 6;
                            break;
                        case "JULIO":
                            mesInt = 7;
                            break;
                        case "AGOSTO":
                            mesInt = 8;
                            break;
                        case "SEPTIEMBRE":
                            mesInt = 9;
                            break;
                        case "OCTUBRE":
                            mesInt = 10;
                            break;
                        case "NOVIEMBRE":
                            mesInt = 11;
                            break;
                        case "DICIEMBRE":
                            mesInt = 12;
                            break;
                    }
                    q++;
                    i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                    if (i > dataSetExcel.Tables[0].Columns.Count)
                    {
                        throw new Exception("No se encontro la columna: " + lstParExcelColumna[q].Pec_Columna.ToString() + ". Por favor revise la hoja excel " + hojaexcelse.ToString());
                    }
                }
                if (dataSetExcel.Tables[0].Rows[f][i].ToString().Trim() != "")
                {
                    objContrato = Contrato_SinonimoController.ExisteSinonimoContrato(dataSetExcel.Tables[0].Rows[f][i].ToString().ToUpper().Trim());
                    parexcel1++;
                    q++;
                    i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                    if (i > dataSetExcel.Tables[0].Columns.Count)
                    {
                        throw new Exception("No se encontro la columna: " + lstParExcelColumna[q].Pec_Columna.ToString() + ". Por favor revise la hoja excel " + hojaexcelse.ToString());
                    }
                }
                if (dataSetExcel.Tables[0].Rows[f][i].ToString().Trim() != "")
                {
                    objCampo = Campo_SinonimoController.ExisteCampoContrato(dataSetExcel.Tables[0].Rows[f][i].ToString().ToUpper().Trim());
                    parexcel1++;
                    if (objContrato != null && objCampo != null)
                    {
                        Regalia regaliaAdd = new Regalia();
                        regaliaAdd.Reg_id = 0;
                        regaliaAdd.Ctt_id = objContrato.Ctt_id;
                        regaliaAdd.Cam_id = objCampo.Cam_id;
                        regaliaAdd.Ani_id = anio;
                        regaliaAdd.Mes_id = mesInt;
                        regaliaAdd.Mon_id = 2;

                        q++;
                        i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                        if (dataSetExcel.Tables[0].Rows[f][i].ToString().StartsWith("REGALIA") || dataSetExcel.Tables[0].Rows[f][i].ToString().StartsWith("REGALIAS"))
                            regaliaAdd.Reg_tipo = "R";
                        else if (dataSetExcel.Tables[0].Rows[f][i].ToString().StartsWith("PARTICIPACION"))
                            regaliaAdd.Reg_tipo = "P";
                        else
                            regaliaAdd.Reg_tipo = "I";

                        q++;
                        i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                        if (dataSetExcel.Tables[0].Rows[f][i].ToString().Trim() != "")
                        {
                            regaliaAdd.Reg_gasmi = decimal.Round(Convert.ToDecimal(dataSetExcel.Tables[0].Rows[f][i].ToString()), 8);
                        }
                        else
                            regaliaAdd.Reg_gasmi = 0;

                        q++;
                        i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                        if (dataSetExcel.Tables[0].Rows[f][i].ToString().Trim() != "")
                        {
                            regaliaAdd.Reg_gasme = decimal.Round(Convert.ToDecimal(dataSetExcel.Tables[0].Rows[f][i].ToString()), 8);
                        }
                        else
                            regaliaAdd.Reg_gasme = 0;

                        q++;
                        i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                        if (dataSetExcel.Tables[0].Rows[f][i].ToString().Trim() != "")
                        {
                            regaliaAdd.Reg_crudomi = decimal.Round(Convert.ToDecimal(dataSetExcel.Tables[0].Rows[f][i].ToString()), 8);
                        }
                        else
                            regaliaAdd.Reg_crudomi = 0;

                        q++;
                        i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                        if (dataSetExcel.Tables[0].Rows[f][i].ToString().Trim() != "")
                        {
                            regaliaAdd.Reg_crudome = decimal.Round(Convert.ToDecimal(dataSetExcel.Tables[0].Rows[f][i].ToString()), 8);
                        }
                        else
                            regaliaAdd.Reg_crudome = 0;

                        q++;
                        i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                        if (dataSetExcel.Tables[0].Rows[f][i].ToString().Trim() != "")
                        {
                            regaliaAdd.Reg_glp = decimal.Round(Convert.ToDecimal(dataSetExcel.Tables[0].Rows[f][i].ToString()), 8);
                        }
                        else
                            regaliaAdd.Reg_glp = 0;

                        regaliaAdd.Reg_total = 0;
                        regaliaAdd.Reg_estado = 1;
                        List<Regalia> lstRegalia = new List<Regalia>();
                        lstRegalia.Add(regaliaAdd);
                        RegaliaController.save(lstRegalia);
                    }
                    q = 0;
                    i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                    if (i > dataSetExcel.Tables[0].Columns.Count)
                    {
                        throw new Exception("No se encontro la columna: " + lstParExcelColumna[q].Pec_Columna.ToString() + ". Por favor revise la hoja excel " + hojaexcelse.ToString());
                    }
                    parexcel1 = 0;
                }
            }
        }

        #endregion



        #region Validadores

        /// <summary>
        /// validacion de las hojas de excel de GN, GNE, GNT, GLP, PCG, PRO
        /// </summary>
        /// <param name="dataSetExcel">data ser con los datos de la hoja</param>
        /// <param name="mes">mes a ser registrado</param>
        /// <param name="anio">anio</param>
        /// <param name="lstParExcel">par excel a procesar.</param>
        /// <returns>retorna true si tuvo exito, false si no tiene excsito</returns>
        public bool ValidarRecorridoColumna(DataSet dataSetExcel, long mes, long anio, List<ParExcel> lstParExcel, string hojaexcelse)
        {
            int valorColumna = recuperarValorNumeralColumna(lstParExcelColumna, 0);
            int cambioColumna = 0;
            int contadorPaxExcelColumna = 0;
            bool flag = false;
            Calculo_VariableController objCalculoVariableController = new Calculo_VariableController();
            List<Calculo_Variable> lstCalculoVariable = new List<Calculo_Variable>();
            List<Titular_Contrato> lstTitularContrato = new List<Titular_Contrato>();

            ParExcel_ColumnaController parExcel_ColummnaController = new ParExcel_ColumnaController();

            List<Campo> lstCampo = null;
            int fila = 0;
            Campo objCampo = null;

            Contrato_Campo[] Contrato_CampoValidador = null;

            lstParExcelColumna = parExcel_ColummnaController.loadBypex_id(lstParExcel[0].Pex_id);

            valorColumna = recuperarValorNumeralColumna(lstParExcelColumna, 0);
            int filaComienzo = (int)lstParExcelColumna[0].Pec_fila - 1;


            for (fila = filaComienzo; fila < dataSetExcel.Tables[0].Rows.Count; fila++)
            {
                if (fila >= 0)
                {
                    if (dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString().Trim() != "")
                    {
                        string total = dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString().Trim().ToUpper();
                        if (!total.StartsWith("TOTAL") || total.Length != 5)
                        {
                            if (dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString().Length <= 50)
                            {
                                lstTitularContrato = Titular_SinonimoController.ExisteTitularSinonimo(dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString().Trim());
                                if (lstTitularContrato != null && lstTitularContrato.Count != 0)
                                {
                                    cambioColumna++;
                                    valorColumna = recuperarValorNumeralColumna(lstParExcelColumna, cambioColumna);
                                    contadorPaxExcelColumna++;
                                    if (valorColumna > dataSetExcel.Tables[0].Columns.Count)
                                    {
                                        throw new Exception("No se encontro la columna: " + lstParExcelColumna[cambioColumna].Pec_Columna.ToString() + ". Por favor revise la hoja excel " + hojaexcelse.ToString());
                                    }
                                }
                                else
                                {
                                    throw new Exception("Por favor verifique la hoja excel: " + hojaexcelse + ", el operador: " + dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString() + " que esta en la fila: " +
                                    (fila + 1).ToString() + " y en la columan: " + recuperarValorLiteralColumna(valorColumna).ToString());
                                }
                            }
                        }
                        else
                        {
                            fila = dataSetExcel.Tables[0].Rows.Count;
                        }

                        lstCampo = new List<Campo>();
                        objCampo = new Campo();
                        for (int c = fila; c < dataSetExcel.Tables[0].Rows.Count; c++)
                        {
                            if (dataSetExcel.Tables[0].Rows[c][valorColumna].ToString().Trim() != "" && dataSetExcel.Tables[0].Rows[c][valorColumna].ToString().Trim().StartsWith("TOTAL") == false && dataSetExcel.Tables[0].Rows[c][valorColumna].ToString().Trim().Length < 50)
                            {
                                objCampo = Campo_SinonimoController.ExisteCampoContrato(dataSetExcel.Tables[0].Rows[c][valorColumna].ToString().Trim().Replace("*", ""));
                                if (objCampo != null)
                                {
                                    lstCampo.Add(objCampo);
                                }
                                else
                                {

                                    throw new Exception("Por favor revise la hoja excel: " + hojaexcelse + ", el campo: " + dataSetExcel.Tables[0].Rows[c][valorColumna].ToString() +
                                        " que esta en la fila: " + (c + 1).ToString() + " y en la columna: " + recuperarValorLiteralColumna(valorColumna).ToString());
                                }
                            }
                            else if (dataSetExcel.Tables[0].Rows[c][valorColumna].ToString().Trim().StartsWith("TOTAL"))
                            {
                                //Verificar que cada campo tengo su respectivo contrato
                                if (lstTitularContrato.Count > 0)
                                {
                                    Contrato_CampoValidador = new Contrato_Campo[lstCampo.Count];
                                    List<Contrato_Campo> lstContratoCampo = new List<Contrato_Campo>();
                                    for (int t = 0; t < lstTitularContrato.Count; t++)
                                    {
                                        lstContratoCampo = ContratoCampoController.GetListContratoCamposPorContrato(lstTitularContrato[t].Ctt_id);
                                        for (int contContrato = 0; contContrato < lstContratoCampo.Count; contContrato++)
                                        {
                                            for (int c1 = 0; c1 < lstCampo.Count; c1++)
                                            {
                                                if (lstCampo[c1].Cam_nombre == lstContratoCampo[contContrato].Cam_nombre)
                                                {
                                                    Contrato_CampoValidador[c1] = lstContratoCampo[contContrato];
                                                }
                                            }
                                        }
                                    }
                                    if (Contrato_CampoValidador.Count() == lstCampo.Count)
                                    {
                                        for (int m = 0; m < lstCampo.Count(); m++)
                                        {
                                            if (Contrato_CampoValidador[m] == null)
                                            {
                                                throw new Exception("Por favor verifique la hoja excel: " + hojaexcelse + " el contrato entre el operador: " + lstTitularContrato[0].Tit_nombre + " y con el campo: " + lstCampo[m].Cam_nombre);
                                            }
                                        }
                                        cambioColumna = 0;
                                        valorColumna = recuperarValorNumeralColumna(lstParExcelColumna, cambioColumna);
                                        contadorPaxExcelColumna = 0;
                                        fila = c;
                                        c = dataSetExcel.Tables[0].Rows.Count;
                                        if (cambioColumna > dataSetExcel.Tables[0].Columns.Count)
                                        {
                                            throw new Exception("No se encontro la columna: " + lstParExcelColumna[cambioColumna].Pec_Columna.ToString() + ". Por favor revise la hoja excel " + hojaexcelse.ToString());
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
            flag = objCalculoVariableController.ValidaCalculo(anio, mes, lstParExcel[0].Pex_id, 0, lstParExcel[0].Tcl_id);
            return flag;
        }

        /// <summary>
        /// validacion de las hoja de excel INVERSIONES Y COSTO, TITULAR
        /// </summary>
        /// <param name="dataSetExcel">Datos a ser almacenados</param>
        /// <param name="lstParExcel">configuracion de la hoja excel</param>
        /// <param name="mes">mes a ser registrado</param>
        /// <param name="anio">anio a ser registrado</param>
        /// <param name="ctt_id">contrato al que se registrara</param>
        /// <returns></returns>
        public bool validaRecorridoFila(DataSet dataSetExcel, List<ParExcel> lstParExcel, long mes, long anio, long ctt_id, string hojaexcelse)
        {
            int valorColumna = recuperarValorNumeralColumna(lstParExcelColumna, 0);
            bool flag;
            Calculo_VariableController objCalculoVariableController = new Calculo_VariableController();
            List<Calculo_Variable> lstCalculoVariable = new List<Calculo_Variable>();
            List<Titular_Contrato> lstTitularContrato = new List<Titular_Contrato>();


            flag = objCalculoVariableController.ValidaCalculo(anio, mes, lstParExcel[0].Pex_id, ctt_id, lstParExcel[0].Tcl_id);
            return flag;
        }


        /// <summary>
        /// validacion de la hoja excel de certificación
        /// </summary>
        /// <param name="dataSetExcel">datos a ser agregados</param>
        /// <param name="lstParExcel">lista de configuracion de la hoja excel</param>
        /// <returns></returns>
        public bool validarRecorridoNormal(long anio_id, long mes_id, DataSet dataSetExcel, List<ParExcel> lstParExcel, string hojaexcelse)
        {
            int valorColumna = recuperarValorNumeralColumna(lstParExcelColumna, 0);
            int contadorPaxExcelColumna = 0;
            bool flag = false;
            Calculo_VariableController objCalculoVariableController = new Calculo_VariableController();
            List<Calculo_Variable> lstCalculoVariable = new List<Calculo_Variable>();
            List<Titular_Contrato> lstTitularContrato = new List<Titular_Contrato>();

            ParExcel_ColumnaController parExcel_ColummnaController = new ParExcel_ColumnaController();

            List<Campo> lstCampo = null;
            int fila = 0;
            Campo objCampo = null;

            Contrato_Campo[] contratoCampoValidador = null;

            lstParExcelColumna = parExcel_ColummnaController.loadBypex_id(lstParExcel[0].Pex_id);
            int q = 2;
            valorColumna = recuperarValorNumeralColumna(lstParExcelColumna, q);
            int filaComienzo = (int)lstParExcelColumna[0].Pec_fila - 1;


            for (fila = filaComienzo; fila < dataSetExcel.Tables[0].Rows.Count; fila++)
            {
                if (fila >= 0)
                {
                    if (dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString().Trim() != "")
                    {
                        if (dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString().Length <= 50)
                        {
                            lstTitularContrato = Titular_SinonimoController.ExisteTitularSinonimo(dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString().Trim());
                            if (lstTitularContrato.Count != 0)
                            {
                                q++;
                                valorColumna = recuperarValorNumeralColumna(lstParExcelColumna, q);
                                contadorPaxExcelColumna++;
                                if (valorColumna > dataSetExcel.Tables[0].Columns.Count)
                                {
                                    throw new Exception("No se encontro la columna: " + lstParExcelColumna[q].Pec_Columna.ToString() + ". Por favor revise la hoja excel " + hojaexcelse.ToString());
                                }
                            }
                            else
                            {
                                throw new Exception("Por favor verifique la hoja excel: " + hojaexcelse + ", el operador: " + dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString() + " que esta en la fila: " +
                                (fila + 1).ToString() + "y en la columan: " + recuperarValorLiteralColumna(valorColumna).ToString());
                            }
                            lstCampo = new List<Campo>();
                            objCampo = new Campo();
                            objCampo = Campo_SinonimoController.ExisteCampoContrato(dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString().Trim().Replace("*", ""));
                            if (objCampo != null)
                            {
                                lstCampo.Add(objCampo);
                            }
                            else
                            {
                                throw new Exception("Por favor revise la hoja excel: " + hojaexcelse + ", el campo: " + dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString() +
                                    " que esta en la fila: " + (fila + 1).ToString() + " y en la columna: " + recuperarValorLiteralColumna(valorColumna).ToString());
                            }
                            //Verificar que cada campo tengo su respectivo contrato
                            if (lstTitularContrato.Count > 0)
                            {
                                contratoCampoValidador = new Contrato_Campo[lstCampo.Count];
                                List<Contrato_Campo> lstContratoCampo = new List<Contrato_Campo>();
                                for (int t = 0; t < lstTitularContrato.Count; t++)
                                {
                                    lstContratoCampo = ContratoCampoController.GetListContratoCamposPorContrato(lstTitularContrato[t].Ctt_id);
                                    for (int contContrato = 0; contContrato < lstContratoCampo.Count; contContrato++)
                                    {
                                        for (int c1 = 0; c1 < lstCampo.Count; c1++)
                                        {
                                            if (lstCampo[c1].Cam_nombre == lstContratoCampo[contContrato].Cam_nombre)
                                            {
                                                contratoCampoValidador[c1] = lstContratoCampo[contContrato];
                                                t = lstTitularContrato.Count;
                                                contContrato = lstContratoCampo.Count;
                                            }
                                        }
                                    }
                                }
                                if (contratoCampoValidador.Count() == lstCampo.Count)
                                {
                                    for (int m = 0; m < lstCampo.Count(); m++)
                                    {
                                        if (contratoCampoValidador[m] == null)
                                        {
                                            throw new Exception("Por favor verifique la hoja excel: " + hojaexcelse +
                                                ", el contrato entre el operador: " +
                                                lstTitularContrato[0].Tit_nombre + ", con el campo: "
                                                + lstCampo[m].Cam_nombre);
                                        }
                                    }
                                    q = 2;
                                    valorColumna = recuperarValorNumeralColumna(lstParExcelColumna, q);
                                    if (valorColumna > dataSetExcel.Tables[0].Columns.Count)
                                    {
                                        throw new Exception("No se encontro la columna: " + lstParExcelColumna[q].Pec_Columna.ToString() + ". Por favor revise la hoja excel " + hojaexcelse.ToString());
                                    }
                                }

                            }
                        }
                    }
                }
            }
            flag = objCalculoVariableController.ValidaCalculo(anio_id, mes_id, lstParExcel[0].Pex_id, 0, lstParExcel[0].Tcl_id);
            return flag;
        }

        /// <summary>
        /// validacion de IDh, REGALIAS y PARTICIPACIONES
        /// </summary>
        /// <param name="dataselExcel">Datos a ser agregados</param>
        /// <param name="lstParExcel">configuracion de la hoja excel</param>
        /// <returns></returns>
        public bool validarAuxiliarIDHyREG(long anio_id, long mes_id, DataSet dataSetExcel, List<ParExcel> lstParExcel, string reg_tipo, string reg_tipo2, string hojaexcelse)
        {
            List<Regalia> lstRegalia = new List<Regalia>();
            Contrato objContrato = new Contrato();
            Campo objcampo = new Campo();

            ParExcel_ColumnaController parExcel_ColummnaController = new ParExcel_ColumnaController();

            lstParExcelColumna = parExcel_ColummnaController.loadBypex_id(lstParExcel[0].Pex_id);

            int fila = (int)lstParExcelColumna[0].Pec_fila - 1;
            int parexcel1 = 0;
            int anio = 0;
            int mesInt = 0;
            string mes;
            int q = 0;
            int i = recuperarValorNumeralColumna(lstParExcelColumna, q);
            for (int f = fila; f < dataSetExcel.Tables[0].Rows.Count; f++)
            {
                if (dataSetExcel.Tables[0].Rows[f][i].ToString().Trim() != "")
                {
                    anio = int.Parse(dataSetExcel.Tables[0].Rows[f][i].ToString().Trim().ToUpper());
                    if (anio != anio_id)
                        throw new Exception("por favor verifique el año de la fila: " + (f + 1).ToString() +
                            " y de la columna: " + recuperarValorLiteralColumna(i).ToString());
                    parexcel1++;
                    q++;
                    i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                    if (i > dataSetExcel.Tables[0].Columns.Count)
                    {
                        throw new Exception("No se encontro la columna: " + lstParExcelColumna[q].Pec_Columna.ToString() + ". Por favor revise la hoja excel " + hojaexcelse.ToString());
                    }
                }
                if (dataSetExcel.Tables[0].Rows[f][i].ToString().Trim() != "")
                {
                    mes = dataSetExcel.Tables[0].Rows[f][i].ToString().ToUpper().Trim();
                    parexcel1++;
                    switch (mes)
                    {
                        case "ENERO":
                            mesInt = 1;
                            break;
                        case "FEBRERO":
                            mesInt = 2;
                            break;
                        case "MARZO":
                            mesInt = 3;
                            break;
                        case "ABRIL":
                            mesInt = 4;
                            break;
                        case "MAYO":
                            mesInt = 5;
                            break;
                        case "JUNIO":
                            mesInt = 6;
                            break;
                        case "JULIO":
                            mesInt = 7;
                            break;
                        case "AGOSTO":
                            mesInt = 8;
                            break;
                        case "SEPTIEMBRE":
                            mesInt = 9;
                            break;
                        case "OCTUBRE":
                            mesInt = 10;
                            break;
                        case "NOVIEMBRE":
                            mesInt = 11;
                            break;
                        case "DICIEMBRE":
                            mesInt = 12;
                            break;
                    }
                    if (mesInt != mes_id)
                        throw new Exception("por favor verifique el mes de la fila: " + (f + 1).ToString() +
                               " y de la columna: " + recuperarValorLiteralColumna(i).ToString());
                    q++;
                    i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                    if (i > dataSetExcel.Tables[0].Columns.Count)
                    {
                        throw new Exception("No se encontro la columna: " + lstParExcelColumna[q].Pec_Columna.ToString() + ". Por favor revise la hoja excel " + hojaexcelse.ToString());
                    }
                }
                if (dataSetExcel.Tables[0].Rows[f][i].ToString().Trim() != "")
                {
                    objContrato = Contrato_SinonimoController.ExisteSinonimoContrato(dataSetExcel.Tables[0].Rows[f][i].ToString().ToUpper().Trim());
                    if (objContrato == null)
                        throw new Exception("Por favor revise el contrato: " + dataSetExcel.Tables[0].Rows[f][i].ToString() +
                            " que esta en la fila: " + (f + 1).ToString() + " y en la columna: " + recuperarValorLiteralColumna(i).ToString());
                }
                q++;
                i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                parexcel1++;
                if (dataSetExcel.Tables[0].Rows[f][i].ToString().Trim() != "")
                {
                    objcampo = Campo_SinonimoController.ExisteCampoContrato(dataSetExcel.Tables[0].Rows[f][i].ToString().ToUpper().Trim());
                    if (objcampo == null)
                        throw new Exception("Por favor revise el campo: " + dataSetExcel.Tables[0].Rows[f][i].ToString() +
                            " que esta en la fila: " + (f + 1).ToString() + " y en la columna: " + recuperarValorLiteralColumna(i).ToString());
                }
                q = 0;
                i = recuperarValorNumeralColumna(lstParExcelColumna, q);
                parexcel1 = 0;
                if (i > dataSetExcel.Tables[0].Columns.Count)
                {
                    throw new Exception("No se encontro la columna: " + lstParExcelColumna[q].Pec_Columna.ToString() + ". Por favor revise la hoja excel " + hojaexcelse.ToString());
                }
            }
            lstRegalia = RegaliaController.listRegaliaByAnioAndMes(anio_id, mes_id, reg_tipo, reg_tipo2);
            if (lstRegalia.Count > 0)
                return true;
            return false;
        }

        #endregion




        #region Operaciones auxiliares


        /// <summary>
        /// recupero el valor de i para la busqueda por las filas.
        /// </summary>
        /// <param name="lstparExcelColumna">Lista de ExcelColumna</param>
        /// <returns>la collumna del excel</returns>
        private int recuperarValorNumeralColumna(List<ParExcel_Columna> lstparExcelColumna, int z)
        {
            string column = "";
            int i = 0;
            string[] cadena = {"A","B","C","D","E","F","G","H","I","J",
                                   "K","L","M","N","O","P","Q","R","S","T",
                                   "U","V","W","X","Y","Z","AA","AB","AC","AD",
                                   "AE","AF","AG","AH","AI","AJ","AK","AL","AM","AN",
                                   "AO","AP","AQ","AR","AS","AT","AU","AV","AW","AX",
                                   "AY","AZ","BA","BB","BC","BD","BE","BF","BG","BH",
                                   "BI","BJ","BK","BL","BM","BN","BO","BP","BQ","BR",
                                   "BS","BT","BU","BV","BW","BX","BY","BZ","CA","CB",
                                   "CC","CD","CE","CF","CG","CH","CI","CJ","CK","CL",
                                   "CM","CN","CO","CP","CQ","CR","CS","CT","CU","CV",
                                   "CW","CX","CY","CZ"};
            if (lstparExcelColumna.Count != 0)
            {
                column = lstparExcelColumna[z].Pec_Columna;
                
                //foreach (string item in cadena)
                //{
                //    if (column.ToUpper() != item.ToString())
                //    {
                //        i++;
                //    }
                //    else
                //        break;
                //}
                for (int f = 0; f <= cadena.Count(); f++)
                {
                    if (column.ToUpper() != cadena[i].ToString())
                    {
                        i++;
                    }
                    else
                        break;

                }
            }
            if (i == cadena.Count())
            {
                i = -1;
            }
            return i;
        }

        public void eliminarCalculo_variable(long anio_id, long mes_id, List<ParExcel> lstParexcel, long ctt_id)
        {
            Calculo_VariableController objCalculoVariableController = new Calculo_VariableController();
            objCalculoVariableController.Eliminar(anio_id, mes_id, lstParexcel[0].Pex_id, lstParexcel[0].Tcl_id, ctt_id);
        }


        public void ActualizarRegaliasIDH(long anio_id, long mes_id, char reg_tipo)
        {
            RegaliaController.EliminarRegaliazIDH(mes_id, anio_id, reg_tipo);
        }


        private string recuperarValorLiteralColumna(int num)
        {
            string column = "";
            if (num > 0)
            {
                string[] cadena = {"A","B","C","D","E","F","G","H","I","J",
                                   "K","L","M","N","O","P","Q","R","S","T",
                                   "U","V","W","X","Y","Z","AA","AB","AC","AD",
                                   "AE","AF","AG","AH","AI","AJ","AK","AL","AM","AN",
                                   "AO","AP","AQ","AR","AS","AT","AU","AV","AW","AX",
                                   "AY","AZ","BA","BB","BC","BD","BE","BF","BG","BH",
                                   "BI","BJ","BK","BL","BM","BN","BO","BP","BQ","BR",
                                   "BS","BT","BU","BV","BW","BX","BY","BZ","CA","CB",
                                   "CC","CD","CE","CF","CG","CH","CI","CJ","CK","CL",
                                   "CM","CN","CO","CP","CQ","CR","CS","CT","CU","CV",
                                   "CW","CX","CY","CZ"};
                for (int v = 0; v <= num; v++)
                {
                    column = cadena[v];
                }
            }
            return column;
        }
        #endregion
    }
}
