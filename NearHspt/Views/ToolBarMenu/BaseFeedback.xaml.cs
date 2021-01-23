﻿// ..............................................................
// Copyright @ 2021  CNG Internet Software, LLC
//
// Project: Nearby Hospital / ER
//
// Name: Feedback
// Vers: 5.1.0.0
//
// Feedback via text, email
// .............................................................
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NearHspt.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseFeedback : ContentPage
  {


    public BaseFeedback()
    {
      InitializeComponent();

      Title = "Your Feedback";
      BackgroundColor = Color.Black;

    }



    // .......................................................................................
    // "Send" pressed
    //
    // .......................................................................................
    private async void SfButton_Send_ClickedAsync(object sender, EventArgs e)
    {
      try
      {
        await Process_EmailAsync();
      }
      catch (Exception ex)
      {
        _ = ex.Message.ToString();
      }
    }


    // .......................................................................................
    // Process plain email
    //
    // .......................................................................................
    private async Task Process_EmailAsync()
    {
      // waiting 5 seconds if system is on test
      //ccWait(5);
      //
      string thisName = sendName.Text;
      string thisEmail = sendEmail.Text;
      string withThisMsg = sendMesssage.Text;
      string nowTime = DateTime.Now.ToString();
      string subject11;
      string body11;
      List<string> toAddress11 = new List<string>();

      try
      {
        subject11 = ("A Message re: 'Nearby Hospitals / ER'");
        body11 = (nowTime + "\nI have some suggestions to improve this app.:\n\n") + "Name: " + thisName + "\n" + "Email: " + thisEmail + "\n" + "Message: " + withThisMsg + "\n";
        toAddress11.Add("service@CNGInternet.com");
        var message = new EmailMessage
        {
          Subject = subject11,
          Body = body11,
          To = toAddress11,
          //Cc = ccRecipients,
          //Bcc = bccRecipients
        };
        await Email.ComposeAsync(message);
      }
      catch (Exception ex)
      {
        _ = ex.Message.ToString();
      }
    }


  }
}
