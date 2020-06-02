﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace Arqueng
{


    public partial class frmPrincipal : Form
    {


        public frmPrincipal()
        {
            InitializeComponent();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        /*
         
        private void AbrirFormInPanel(object Formfilho)
        {
            if (this.pnlMain.Controls.Count > 0)
                this.pnlMain.Controls.RemoveAt(0);
            
            Form fh = Formfilho as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(fh);
            this.pnlMain.Tag = fh;
            fh.Show();
        }

        */
        
        private void OcultaControles()
        {
            pnlCtrlDashboard.Visible = false;
            pnlCtrlOS.Visible = false;
            pnlCtrlAgencias.Visible = false;
            pnlCtrlAtividades.Visible = false;
            pnlCtrlProfissionais.Visible = false;
        }

        private void pnlTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void btnNovaOS_Click(object sender, EventArgs e)
        {
            OcultaControles();
            pnlCtrlOS.Visible = true;
            lblTitulo.Text = "Ordens de Serviços";

            frmOS frm = new frmOS { TopLevel = false, Dock = DockStyle.Fill };
            this.pnlMain.Controls.Clear();
            this.pnlMain.Controls.Add(frm);
            frm.Show();
        }


        private void btnSobre_Click(object sender, EventArgs e)
        {
            OcultaControles();
            lblTitulo.Text = "Sobre";
            
            frmSobre frm = new frmSobre { TopLevel = false, Dock = DockStyle.Fill };
            this.pnlMain.Controls.Clear();
            this.pnlMain.Controls.Add(frm);
            frm.Show();
        }


        private void btnProfissionais_Click(object sender, EventArgs e)
        {
            OcultaControles();
            pnlCtrlProfissionais.Visible = true;
            lblTitulo.Text = "Profissionais";
            
            frmProfissionais frm = new frmProfissionais { TopLevel = false, Dock = DockStyle.Fill };
            this.pnlMain.Controls.Clear();
            this.pnlMain.Controls.Add(frm);
            frm.Show();
        }


        private void btnAtividades_Click(object sender, EventArgs e)
        {
            OcultaControles();
            pnlCtrlAtividades.Visible = true;
            lblTitulo.Text = "Atividades";

            frmAtividades frm = new frmAtividades { TopLevel = false, Dock = DockStyle.Fill };
            this.pnlMain.Controls.Clear();
            this.pnlMain.Controls.Add(frm);
            frm.Show();
        }


        private void btnAgencias_Click(object sender, EventArgs e)
        {
             OcultaControles();
             pnlCtrlAgencias.Visible = true;
             lblTitulo.Text = "Agências Demandantes";
            
            frmAgencias frm = new frmAgencias { TopLevel = false, Dock = DockStyle.Fill };
            this.pnlMain.Controls.Clear();
            this.pnlMain.Controls.Add(frm);
            frm.Show();

        }


        private void btnAppClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnSlide_Click(object sender, EventArgs e)
        {
            if (pnlMenu.Width == 200)
            {
                pnlMenu.Width = 50;
                ttpMenu.Active = true;
            }
            else
            {
                pnlMenu.Width = 200;
                ttpMenu.Active = false;
            }    
        }


        private void btnDadosCadastrais_Click(object sender, EventArgs e)
        {
            OcultaControles();
            lblTitulo.Text = "Dados Cadastrais";
            
            frmDadosCadastrais frm = new frmDadosCadastrais { TopLevel = false, Dock = DockStyle.Fill };
            this.pnlMain.Controls.Clear();
            this.pnlMain.Controls.Add(frm);
            frm.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OcultaControles();
            pnlCtrlDashboard.Visible = true;
            lblTitulo.Text = "Dashboard";

            frmDashboard frm = new frmDashboard { TopLevel = false, Dock = DockStyle.Fill };
            this.pnlMain.Controls.Clear();
            this.pnlMain.Controls.Add(frm);
            frm.Show();
        }


        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            frmDashboard frm = new frmDashboard { TopLevel = false, Dock = DockStyle.Fill };
            this.pnlMain.Controls.Clear();
            this.pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void pnlTitulo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
