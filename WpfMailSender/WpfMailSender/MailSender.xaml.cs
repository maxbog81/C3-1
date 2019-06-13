﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;

namespace WpfMailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MailSender : Window
    {
        public MailSender()
        {
            InitializeComponent();
        }

        private void SendMailButton_Click(object sender, RoutedEventArgs e)
        {
            SmtpServer.Subject = SubjectTextBox.Text;
            SmtpServer.Body = BodyTextBox.Text;

            EmailSendServiceClass SendMail = new EmailSendServiceClass();

            SendMail.MailSend(passwordBox.Password);
        }
    }
}
