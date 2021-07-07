using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceImpls
{
    public class EmailComposer : IEmailComposer
    {

        public string ComposeBookingCancelation(Booking booking)
        {
            throw new NotImplementedException();
        }

        public string ComposeBookingConfirmation(Booking booking)
        {
            throw new NotImplementedException();
        }

        public string ComposeConfirmEmail(string name, string confirmUrl)
        {
            string body = @"
<table
                  cellpadding=""0""
                  cellspacing=""0""
                  border=""0""
                  width=""88%""
                  style=""width: 88% !important; min-width: 88%; max-width: 88%""
                >
                  <tr>
                    <td align=""left"" valign=""top"">
                      <font
                        face=""'Source Sans Pro', sans-serif""
                        color=""#1a1a1a""
                        style=""
                          font-size: 52px;
                          line-height: 60px;
                          font-weight: 300;
                          letter-spacing: -1.5px;
                        ""
                      >
                        <span
                          style=""
                            font-family: 'Source Sans Pro', Arial, Tahoma,
                              Geneva, sans-serif;
                            color: #1a1a1a;
                            font-size: 52px;
                            line-height: 60px;
                            font-weight: 300;
                            letter-spacing: -1.5px;
                          ""
                          >Hey " + name + @",</span
                        >
                      </font>
                      <div
                        style=""height: 33px; line-height: 33px; font-size: 31px""
                      >
                        &nbsp;
                      </div>
                      <font
                        face=""'Source Sans Pro', sans-serif""
                        color=""#585858""
                        style=""font-size: 24px; line-height: 32px""
                      >
                        <span
                          style=""
                            font-family: 'Source Sans Pro', Arial, Tahoma,
                              Geneva, sans-serif;
                            color: #585858;
                            font-size: 24px;
                            line-height: 32px;
                          ""
                          >Congratulations on successfully creating a new
                          account. We are very happy to have you as a new member
                          of the Toure family. <br /><br />In order to complete
                          the registration process, please confirm your email
                          account.</span
                        >
                      </font>
                      <div
                        style=""height: 20px; line-height: 20px; font-size: 18px""
                      >
                        &nbsp;
                      </div>
                      <div
                        style=""height: 33px; line-height: 33px; font-size: 31px""
                      >
                        &nbsp;
                      </div>
                      <table
                        class=""mob_btn""
                        cellpadding=""0""
                        cellspacing=""0""
                        border=""0""
                        style=""background: #484848; border-radius: 4px""
                      >
                        <tr>
                          <td align=""center"" valign=""top"">
                            <a
                              href=""" + confirmUrl + @"""
                              target=""_blank""
                              style=""
                                display: block;
                                border: 1px solid #484848;
                                border-radius: 4px;
                                padding: 12px 23px;
                                font-family: 'Source Sans Pro', Arial, Verdana,
                                  Tahoma, Geneva, sans-serif;
                                color: #ffffff;
                                font-size: 20px;
                                line-height: 30px;
                                text-decoration: none;
                                white-space: nowrap;
                                font-weight: 600;
                              ""
                            >
                              <font
                                face=""'Source Sans Pro', sans-serif""
                                color=""#ffffff""
                                style=""
                                  font-size: 20px;
                                  line-height: 30px;
                                  text-decoration: none;
                                  white-space: nowrap;
                                  font-weight: 600;
                                ""
                              >
                                <span
                                  style=""
                                    font-family: 'Source Sans Pro', Arial,
                                      Verdana, Tahoma, Geneva, sans-serif;
                                    color: #ffffff;
                                    font-size: 20px;
                                    line-height: 30px;
                                    text-decoration: none;
                                    white-space: nowrap;
                                    font-weight: 600;
                                  ""
                                  >Confirm&nbsp;Email</span
                                >
                              </font>
                            </a>
                          </td>
                        </tr>
                      </table>
                      <div
                        style=""height: 75px; line-height: 75px; font-size: 73px""
                      >
                        &nbsp;
                      </div>
                    </td>
                  </tr>
                </table>

                <table
                  cellpadding=""0""
                  cellspacing=""0""
                  border=""0""
                  width=""90%""
                  style=""
                    width: 90% !important;
                    min-width: 90%;
                    max-width: 90%;
                    border-width: 1px;
                    border-style: solid;
                    border-color: #e8e8e8;
                    border-bottom: none;
                    border-left: none;
                    border-right: none;
                  ""
                >
                  <tr>
                    <td align=""left"" valign=""top"">
                      <div
                        style=""height: 15px; line-height: 15px; font-size: 13px""
                      >
                        &nbsp;
                      </div>
                    </td>
                  </tr>
                </table>

                <table
                  cellpadding=""0""
                  cellspacing=""0""
                  border=""0""
                  width=""88%""
                  style=""width: 88% !important; min-width: 88%; max-width: 88%""
                >
                  <tr>
                    <td align=""center"" valign=""top"">
                      <!--[if (gte mso 9)|(IE)]>
                           <table border=""0"" cellspacing=""0"" cellpadding=""0"">
                           <tr><td align=""center"" valign=""top"" width=""50""><![endif]-->
                      <div
                        style=""
                          display: inline-block;
                          vertical-align: top;
                          width: 50px;
                        ""
                      >
                        <table
                          cellpadding=""0""
                          cellspacing=""0""
                          border=""0""
                          width=""100%""
                          style=""
                            width: 100% !important;
                            min-width: 100%;
                            max-width: 100%;
                          ""
                        >
                          <tr>
                            <td align=""center"" valign=""top"">
                              <div
                                style=""
                                  height: 13px;
                                  line-height: 13px;
                                  font-size: 11px;
                                ""
                              >
                                &nbsp;
                              </div>
                              <div style=""display: block; max-width: 50px"">
                                <img
                                  src=""https://store.playstation.com/store/api/chihiro/00_09_000/container/US/en/19/UP3493-CUSA07861_00-AV00000000000143/image?_version=00_09_000&platform=chihiro&w=960&h=960&bg_color=000000&opacity=100""
                                  alt=""img""
                                  width=""50""
                                  border=""0""
                                  style=""display: block; width: 50px""
                                />
                              </div>
                            </td>
                          </tr>
                        </table>
                      </div>
                      <!--[if (gte mso 9)|(IE)]></td><td align=""left"" valign=""top"" width=""390""><![endif]-->
                      <div
                        class=""mob_div""
                        style=""
                          display: inline-block;
                          vertical-align: top;
                          width: 62%;
                          min-width: 260px;
                        ""
                      >
                        <table
                          cellpadding=""0""
                          cellspacing=""0""
                          border=""0""
                          width=""100%""
                          style=""
                            width: 100% !important;
                            min-width: 100%;
                            max-width: 100%;
                          ""
                        >
                          <tr>
                            <td
                              width=""18""
                              style=""
                                width: 18px;
                                max-width: 18px;
                                min-width: 18px;
                              ""
                            >
                              &nbsp;
                            </td>
                            <td class=""mob_center"" align=""left"" valign=""top"">
                              <div
                                style=""
                                  height: 13px;
                                  line-height: 13px;
                                  font-size: 11px;
                                ""
                              >
                                &nbsp;
                              </div>
                              <font
                                face=""'Source Sans Pro', sans-serif""
                                color=""#000000""
                                style=""
                                  font-size: 19px;
                                  line-height: 23px;
                                  font-weight: 600;
                                ""
                              >
                                <span
                                  style=""
                                    font-family: 'Source Sans Pro', Arial,
                                      Tahoma, Geneva, sans-serif;
                                    color: #000000;
                                    font-size: 19px;
                                    line-height: 23px;
                                    font-weight: 600;
                                  ""
                                  >MeowMoew</span
                                >
                              </font>
                              <div
                                style=""
                                  height: 1px;
                                  line-height: 1px;
                                  font-size: 1px;
                                ""
                              >
                                &nbsp;
                              </div>
                              <font
                                face=""'Source Sans Pro', sans-serif""
                                color=""#7f7f7f""
                                style=""font-size: 19px; line-height: 23px""
                              >
                                <span
                                  style=""
                                    font-family: 'Source Sans Pro', Arial,
                                      Tahoma, Geneva, sans-serif;
                                    color: #7f7f7f;
                                    font-size: 19px;
                                    line-height: 23px;
                                  ""
                                  >Toure Chief Executive</span
                                >
                              </font>
                            </td>
                            <td
                              width=""18""
                              style=""
                                width: 18px;
                                max-width: 18px;
                                min-width: 18px;
                              ""
                            >
                              &nbsp;
                            </td>
                          </tr>
                        </table>
                      </div>
                      <!--[if (gte mso 9)|(IE)]></td><td align=""left"" valign=""top"" width=""177""><![endif]-->
                      <div
                        style=""
                          display: inline-block;
                          vertical-align: top;
                          width: 177px;
                        ""
                      >
                        <table
                          cellpadding=""0""
                          cellspacing=""0""
                          border=""0""
                          width=""100%""
                          style=""
                            width: 100% !important;
                            min-width: 100%;
                            max-width: 100%;
                          ""
                        >
                          <tr>
                            <td align=""center"" valign=""top"">
                              <div
                                style=""
                                  height: 13px;
                                  line-height: 13px;
                                  font-size: 11px;
                                ""
                              >
                                &nbsp;
                              </div>
                              <div style=""display: block; max-width: 177px"">
                                <img
                                  src=""https://etourimages.blob.core.windows.net/images/signature.png""
                                  alt=""img""
                                  width=""177""
                                  border=""0""
                                  style=""
                                    display: block;
                                    width: 177px;
                                    max-width: 100%;
                                  ""
                                />
                              </div>
                            </td>
                          </tr>
                        </table>
                      </div>
                      <!--[if (gte mso 9)|(IE)]>
                           </td></tr>
                           </table><![endif]-->
                      <div
                        style=""height: 30px; line-height: 30px; font-size: 28px""
                      >
                        &nbsp;
                      </div>
                    </td>
                  </tr>
                </table>";
            return AddHeaderFooter(body);
        }

        public string ComposeResetPassword(string name, string confirmUrl)
        {
            throw new NotImplementedException();
        }

        public string ComposeTripPromotion(Trip trip, string detailUrl, string bookingUrl)
        {

            String body = "<link" +
            "  href=\"https://fonts.googleapis.com/css?family=Work+Sans:300,400,500,600,700\"" +
            "  rel=\"stylesheet\"" +
            "/>" +
            "<link" +
            "  href=\"https://fonts.googleapis.com/css?family=Quicksand:300,400,700\"" +
            "  rel=\"stylesheet\"" +
            "/>" +
            "" +
            "<style type=\"text/css\">" +
            "  .style-1 del {" +
            "    color: rgba(255, 0, 0, 0.5);" +
            "    text-decoration: none;" +
            "    position: relative;" +
            "  }" +
            "  .style-1 del:before {" +
            "    content: \" \";" +
            "    display: block;" +
            "    width: 100%;" +
            "    border-top: 2px solid rgba(255, 0, 0, 0.8);" +
            "    height: 12px;" +
            "    position: absolute;" +
            "    bottom: 0;" +
            "    left: 0;" +
            "    transform: rotate(-7deg);" +
            "  }" +
            "  .style-1 ins {" +
            "    color: green;" +
            "    font-size: 32px;" +
            "    text-decoration: none;" +
            "    padding: 1em 1em 1em 0.5em;" +
            "  }" +
            "</style>" +
            "<!-- [if gte mso 9]><style type=”text/css”>" +
            "        body {" +
            "        font-family: arial, sans-serif!important;" +
            "        }" +
            "        </style>" +
            "    <![endif]-->" +
            "" +
            "<!-- big image section -->" +
            "<table" +
            "  border=\"0\"" +
            "  width=\"100%\"" +
            "  cellpadding=\"0\"" +
            "  cellspacing=\"0\"" +
            "  bgcolor=\"ffffff\"" +
            "  class=\"bg_color\"" +
            ">" +
            "  <tr>" +
            "    <td align=\"center\">" +
            "      <table" +
            "        border=\"0\"" +
            "        align=\"center\"" +
            "        width=\"590\"" +
            "        cellpadding=\"0\"" +
            "        cellspacing=\"0\"" +
            "        class=\"container590\"" +
            "      >" +
            "        <tr>" +
            "          <td align=\"center\" class=\"section-img\">" +
            "            <a" +
            "              href=\"\"" +
            "              style=\"" +
            "                border-style: none !important;" +
            "                display: block;" +
            "                border: 0 !important;" +
            "              \"" +
            "              ><img" +
            $"                src=\"{trip.Tour.ImageUrls[0]}\"" +
            "                style=\"display: block; width: 590px\"" +
            "                width=\"590\"" +
            "                border=\"0\"" +
            "                alt=\"\"" +
            "            /></a>" +
            "          </td>" +
            "        </tr>" +
            "        <tr>" +
            "          <td height=\"20\" style=\"font-size: 20px; line-height: 20px\"> </td>" +
            "        </tr>" +
            "        <tr>" +
            "          <td" +
            "            align=\"center\"" +
            "            style=\"" +
            "              color: #343434;" +
            "              font-size: 24px;" +
            "              font-family: Quicksand, Calibri, sans-serif;" +
            "              font-weight: 700;" +
            "              letter-spacing: 3px;" +
            "              line-height: 35px;" +
            "            \"" +
            "            class=\"main-header\"" +
            "          >" +
            "            <div style=\"line-height: 35px\">" +
            "              NEW TRIP FOR" +
            $"              <span style=\"color: #5caad2\">{trip.Tour.Title}</span>" +
            "            </div>" +
            "          </td>" +
            "        </tr>" +
            "        <tr>" +
            "          <td height=\"10\" style=\"font-size: 10px; line-height: 10px\"> </td>" +
            "        </tr>" +
            "" +
            "        <tr>" +
            "          <td align=\"center\">" +
            "            <table" +
            "              border=\"0\"" +
            "              width=\"40\"" +
            "              align=\"center\"" +
            "              cellpadding=\"0\"" +
            "              cellspacing=\"0\"" +
            "              bgcolor=\"eeeeee\"" +
            "            >" +
            "              <tr>" +
            "                <td height=\"2\" style=\"font-size: 2px; line-height: 2px\">" +
            "                   " +
            "                </td>" +
            "              </tr>" +
            "            </table>" +
            "          </td>" +
            "        </tr>" +
            "" +
            "        <tr>" +
            "          <td height=\"20\" style=\"font-size: 20px; line-height: 20px\"> </td>" +
            "        </tr>" +
            "" +
            "        <tr>" +
            "          <td align=\"center\">" +
            "            <table" +
            "              border=\"0\"" +
            "              width=\"400\"" +
            "              align=\"center\"" +
            "              cellpadding=\"0\"" +
            "              cellspacing=\"0\"" +
            "              class=\"container590\"" +
            "            >" +
            "              <tr>" +
            "                <td" +
            "                  align=\"center\"" +
            "                  style=\"" +
            "                    color: #888888;" +
            "                    font-size: 16px;" +
            "                    font-family: 'Work Sans', Calibri, sans-serif;" +
            "                    line-height: 24px;" +
            "                  \"" +
            "                >" +
            "                  <!-- style 1 -->" +
            "                  <div class=\"style-1\" style=\"margin-bottom: 1rem\">" +
            "                    <del>" +
            $"                      <span class=\"amount\">${trip.Price}</span>" +
            "                    </del>" +
            "                    <ins>" +
            $"                      <span class=\"amount\">{trip.GetSalePrice().ToString("C")}</span>" +
            "                    </ins>" +
            "                  </div>" +
            "                  <div style=\"line-height: 24px\">" +
            $"                    <p>Open slots: {trip.Vacancies}</p>" +
            $"                    <p>Start place: <span>{trip.Tour.StartPlace}</span></p>" +
            $"                    <p>Destination: <span>{trip.Tour.Destination}</span></p>" +
            $"                    <p>Time Frame: {trip.StartTime.ToString("dd/MM/yyyy")} - {trip.EndTime.ToString("dd/MM/yyyy")}</p>" +
            "                  </div>" +
            "                </td>" +
            "              </tr>" +
            "            </table>" +
            "          </td>" +
            "        </tr>" +
            "" +
            "        <tr>" +
            "          <td height=\"25\" style=\"font-size: 25px; line-height: 25px\"> </td>" +
            "        </tr>" +
            "" +
            "        <tr>" +
            "          <td align=\"center\">" +
            "            <table" +
            "              border=\"0\"" +
            "              align=\"center\"" +
            "              width=\"300\"" +
            "              cellpadding=\"0\"" +
            "              cellspacing=\"0\"" +
            "              style=\"\"" +
            "            >" +
            "              <tr>" +
            "                <td height=\"10\" style=\"font-size: 10px; line-height: 10px\">" +
            "                   " +
            "                </td>" +
            "              </tr>" +
            "" +
            "              <tr style=\"display: flex; justify-content: center\">" +
            "                <td" +
            "                  align=\"center\"" +
            "                  style=\"" +
            "                    color: #ffffff;" +
            "                    font-size: 14px;" +
            "                    margin-right: 1rem;" +
            "                    font-family: 'Work Sans', Calibri, sans-serif;" +
            "                    line-height: 26px;" +
            "                  \"" +
            "                >" +
            "                  <div" +
            "                    style=\"" +
            "                      line-height: 26px;" +
            "                      background-color: #5caad2;" +
            "                      padding: 1rem;" +
            "                      text-align: center;" +
            "                      width: 6rem;" +
            "                    \"" +
            "                  >" +
            $"                    <a href=\"{detailUrl}\" style=\"color: #ffffff; text-decoration: none\"" +
            "                      >DETAILS</a" +
            "                    >" +
            "                  </div>" +
            "                </td>" +
            "" +
            "                <td" +
            "                  align=\"center\"" +
            "                  style=\"" +
            "                    color: #ffffff;" +
            "                    font-size: 14px;" +
            "                    font-family: 'Work Sans', Calibri, sans-serif;" +
            "                    line-height: 26px;" +
            "                  \"" +
            "                >" +
            "                  <div" +
            "                    style=\"" +
            "                      line-height: 26px;" +
            "                      background-color: #dc143c;" +
            "                      padding: 1rem;" +
            "                      text-align: center;" +
            "                      width: 6rem;" +
            "                    \"" +
            "                  >" +
            $"                    <a href=\"{bookingUrl}\" style=\"color: #ffffff; text-decoration: none\"" +
            "                      >BOOK NOW</a" +
            "                    >" +
            "                  </div>" +
            "                </td>" +
            "              </tr>" +
            "" +
            "              <tr>" +
            "                <td height=\"10\" style=\"font-size: 10px; line-height: 10px\">" +
            "                   " +
            "                </td>" +
            "              </tr>" +
            "            </table>" +
            "          </td>" +
            "        </tr>" +
            "      </table>" +
            "    </td>" +
            "  </tr>" +
            "</table>";

            return AddHeaderFooter(body);
        }

        private string AddHeaderFooter(string body)
        {
            return @"
<!DOCTYPE html PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN"" ""http://www.w3.org/TR/html4/loose.dtd"">
<html>
  <head>
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
    <title>Mailto</title>
    <link
      href=""https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700""
      rel=""stylesheet""
    />
    <style type=""text/css"">
      html {
        -webkit-text-size-adjust: none;
        -ms-text-size-adjust: none;
      }

      @media only screen and (min-device-width: 750px) {
        .table750 {
          width: 750px !important;
        }
      }
      @media only screen and (max-device-width: 750px),
        only screen and (max-width: 750px) {
        table[class=""table750""] {
          width: 100% !important;
        }
        .mob_b {
          width: 93% !important;
          max-width: 93% !important;
          min-width: 93% !important;
        }
        .mob_b1 {
          width: 100% !important;
          max-width: 100% !important;
          min-width: 100% !important;
        }
        .mob_left {
          text-align: left !important;
        }
        .mob_soc {
          width: 50% !important;
          max-width: 50% !important;
          min-width: 50% !important;
        }
        .mob_menu {
          width: 50% !important;
          max-width: 50% !important;
          min-width: 50% !important;
          box-shadow: inset -1px -1px 0 0 rgba(255, 255, 255, 0.2);
        }
        .mob_center {
          text-align: center !important;
        }
        .top_pad {
          height: 15px !important;
          max-height: 15px !important;
          min-height: 15px !important;
        }
        .mob_pad {
          width: 15px !important;
          max-width: 15px !important;
          min-width: 15px !important;
        }
        .mob_div {
          display: block !important;
        }
      }
      @media only screen and (max-device-width: 550px),
        only screen and (max-width: 550px) {
        .mod_div {
          display: block !important;
        }
      }
      .table750 {
        width: 750px;
      }
    </style>
  </head>
  <body style=""margin: 0; padding: 0"">
    <table
      cellpadding=""0""
      cellspacing=""0""
      border=""0""
      width=""100%""
      style=""
        background: #f3f3f3;
        min-width: 350px;
        font-size: 1px;
        line-height: normal;
      ""
    >
      <tr>
        <td align=""center"" valign=""top"">
          <!--[if (gte mso 9)|(IE)]>
         <table border=""0"" cellspacing=""0"" cellpadding=""0"">
         <tr><td align=""center"" valign=""top"" width=""750""><![endif]-->
          <table
            cellpadding=""0""
            cellspacing=""0""
            border=""0""
            width=""750""
            class=""table750""
            style=""
              width: 100%;
              max-width: 750px;
              min-width: 350px;
              background: #f3f3f3;
            ""
          >
            <tr>
              <td
                class=""mob_pad""
                width=""25""
                style=""width: 25px; max-width: 25px; min-width: 25px""
              >
                &nbsp;
              </td>
              <td align=""center"" valign=""top"" style=""background: #ffffff"">
                <table
                  cellpadding=""0""
                  cellspacing=""0""
                  border=""0""
                  width=""100%""
                  style=""
                    width: 100% !important;
                    min-width: 100%;
                    max-width: 100%;
                    background: #f3f3f3;
                  ""
                >
                  <tr>
                    <td align=""right"" valign=""top"">
                      <div
                        class=""top_pad""
                        style=""height: 25px; line-height: 25px; font-size: 23px""
                      >
                        &nbsp;
                      </div>
                    </td>
                  </tr>
                </table>

                <table
                  cellpadding=""0""
                  cellspacing=""0""
                  border=""0""
                  width=""88%""
                  style=""width: 88% !important; min-width: 88%; max-width: 88%""
                >
                  <tr>
                    <td align=""left"" valign=""top"">
                      <div
                        style=""height: 39px; line-height: 39px; font-size: 37px""
                      >
                        &nbsp;
                      </div>
                      <a
                        href=""#""
                        target=""_blank""
                        style=""display: block; max-width: 128px""
                      >
                        <img
                          src=""https://etourimages.blob.core.windows.net/images/logo.png""
                          alt=""img""
                          width=""128""
                          border=""0""
                          style=""display: block; width: 128px""
                        />
                      </a>
                      <div
                        style=""height: 73px; line-height: 73px; font-size: 71px""
                      >
                        &nbsp;
                      </div>
                    </td>
                  </tr>
                </table>" + body + @"
                <table
                  cellpadding=""0""
                  cellspacing=""0""
                  border=""0""
                  width=""100%""
                  style=""
                    width: 100% !important;
                    min-width: 100%;
                    max-width: 100%;
                    background: #f3f3f3;
                  ""
                >
                  <tr>
                    <td align=""center"" valign=""top"">
                      <div
                        style=""height: 34px; line-height: 34px; font-size: 32px""
                      >
                        &nbsp;
                      </div>
                      <table
                        cellpadding=""0""
                        cellspacing=""0""
                        border=""0""
                        width=""88%""
                        style=""
                          width: 88% !important;
                          min-width: 88%;
                          max-width: 88%;
                        ""
                      >
                        <tr>
                          <td align=""center"" valign=""top"">
                            <table
                              cellpadding=""0""
                              cellspacing=""0""
                              border=""0""
                              width=""78%""
                              style=""min-width: 300px""
                            >
                              <tr>
                                <td align=""center"" valign=""top"" width=""23%"">
                                  <a
                                    href=""#""
                                    target=""_blank""
                                    style=""
                                      font-family: 'Source Sans Pro', Arial,
                                        Tahoma, Geneva, sans-serif;
                                      color: #1a1a1a;
                                      font-size: 14px;
                                      line-height: 20px;
                                      text-decoration: none;
                                      white-space: nowrap;
                                      font-weight: bold;
                                    ""
                                  >
                                    <font
                                      face=""'Source Sans Pro', sans-serif""
                                      color=""#1a1a1a""
                                      style=""
                                        font-size: 14px;
                                        line-height: 20px;
                                        text-decoration: none;
                                        white-space: nowrap;
                                        font-weight: bold;
                                      ""
                                    >
                                      <span
                                        style=""
                                          font-family: 'Source Sans Pro', Arial,
                                            Tahoma, Geneva, sans-serif;
                                          color: #1a1a1a;
                                          font-size: 14px;
                                          line-height: 20px;
                                          text-decoration: none;
                                          white-space: nowrap;
                                          font-weight: bold;
                                        ""
                                        >HELP&nbsp;CENTER</span
                                      >
                                    </font>
                                  </a>
                                </td>
                                <td align=""center"" valign=""top"" width=""10%"">
                                  <font
                                    face=""'Source Sans Pro', sans-serif""
                                    color=""#1a1a1a""
                                    style=""
                                      font-size: 17px;
                                      line-height: 17px;
                                      font-weight: bold;
                                    ""
                                  >
                                    <span
                                      style=""
                                        font-family: 'Source Sans Pro', Arial,
                                          Tahoma, Geneva, sans-serif;
                                        color: #1a1a1a;
                                        font-size: 17px;
                                        line-height: 17px;
                                        font-weight: bold;
                                      ""
                                      >&bull;</span
                                    >
                                  </font>
                                </td>
                                <td align=""center"" valign=""top"" width=""23%"">
                                  <a
                                    href=""#""
                                    target=""_blank""
                                    style=""
                                      font-family: 'Source Sans Pro', Arial,
                                        Tahoma, Geneva, sans-serif;
                                      color: #1a1a1a;
                                      font-size: 14px;
                                      line-height: 20px;
                                      text-decoration: none;
                                      white-space: nowrap;
                                      font-weight: bold;
                                    ""
                                  >
                                    <font
                                      face=""'Source Sans Pro', sans-serif""
                                      color=""#1a1a1a""
                                      style=""
                                        font-size: 14px;
                                        line-height: 20px;
                                        text-decoration: none;
                                        white-space: nowrap;
                                        font-weight: bold;
                                      ""
                                    >
                                      <span
                                        style=""
                                          font-family: 'Source Sans Pro', Arial,
                                            Tahoma, Geneva, sans-serif;
                                          color: #1a1a1a;
                                          font-size: 14px;
                                          line-height: 20px;
                                          text-decoration: none;
                                          white-space: nowrap;
                                          font-weight: bold;
                                        ""
                                        >SUPPORT&nbsp;24/7</span
                                      >
                                    </font>
                                  </a>
                                </td>
                                <td align=""center"" valign=""top"" width=""10%"">
                                  <font
                                    face=""'Source Sans Pro', sans-serif""
                                    color=""#1a1a1a""
                                    style=""
                                      font-size: 17px;
                                      line-height: 17px;
                                      font-weight: bold;
                                    ""
                                  >
                                    <span
                                      style=""
                                        font-family: 'Source Sans Pro', Arial,
                                          Tahoma, Geneva, sans-serif;
                                        color: #1a1a1a;
                                        font-size: 17px;
                                        line-height: 17px;
                                        font-weight: bold;
                                      ""
                                      >&bull;</span
                                    >
                                  </font>
                                </td>
                                <td align=""center"" valign=""top"" width=""23%"">
                                  <a
                                    href=""#""
                                    target=""_blank""
                                    style=""
                                      font-family: 'Source Sans Pro', Arial,
                                        Tahoma, Geneva, sans-serif;
                                      color: #1a1a1a;
                                      font-size: 14px;
                                      line-height: 20px;
                                      text-decoration: none;
                                      white-space: nowrap;
                                      font-weight: bold;
                                    ""
                                  >
                                    <font
                                      face=""'Source Sans Pro', sans-serif""
                                      color=""#1a1a1a""
                                      style=""
                                        font-size: 14px;
                                        line-height: 20px;
                                        text-decoration: none;
                                        white-space: nowrap;
                                        font-weight: bold;
                                      ""
                                    >
                                      <span
                                        style=""
                                          font-family: 'Source Sans Pro', Arial,
                                            Tahoma, Geneva, sans-serif;
                                          color: #1a1a1a;
                                          font-size: 14px;
                                          line-height: 20px;
                                          text-decoration: none;
                                          white-space: nowrap;
                                          font-weight: bold;
                                        ""
                                        >ACCOUNT</span
                                      >
                                    </font>
                                  </a>
                                </td>
                              </tr>
                            </table>
                            <div
                              style=""
                                height: 34px;
                                line-height: 34px;
                                font-size: 32px;
                              ""
                            >
                              &nbsp;
                            </div>
                            <font
                              face=""'Source Sans Pro', sans-serif""
                              color=""#868686""
                              style=""font-size: 17px; line-height: 20px""
                            >
                              <span
                                style=""
                                  font-family: 'Source Sans Pro', Arial, Tahoma,
                                    Geneva, sans-serif;
                                  color: #868686;
                                  font-size: 17px;
                                  line-height: 20px;
                                ""
                                >Copyright &copy; 2021 Toure.
                                All&nbsp;Rights&nbsp;Reserved.
                                We&nbsp;appreciate&nbsp;you!</span
                              >
                            </font>
                            <div
                              style=""
                                height: 3px;
                                line-height: 3px;
                                font-size: 1px;
                              ""
                            >
                              &nbsp;
                            </div>
                            <font
                              face=""'Source Sans Pro', sans-serif""
                              color=""#1a1a1a""
                              style=""font-size: 17px; line-height: 20px""
                            >
                              <span
                                style=""
                                  font-family: 'Source Sans Pro', Arial, Tahoma,
                                    Geneva, sans-serif;
                                  color: #1a1a1a;
                                  font-size: 17px;
                                  line-height: 20px;
                                ""
                                ><a
                                  href=""#""
                                  target=""_blank""
                                  style=""
                                    font-family: 'Source Sans Pro', Arial,
                                      Tahoma, Geneva, sans-serif;
                                    color: #1a1a1a;
                                    font-size: 17px;
                                    line-height: 20px;
                                    text-decoration: none;
                                  ""
                                  >help@etour.com</a
                                >
                                &nbsp;&nbsp;|&nbsp;&nbsp;
                                <a
                                  href=""#""
                                  target=""_blank""
                                  style=""
                                    font-family: 'Source Sans Pro', Arial,
                                      Tahoma, Geneva, sans-serif;
                                    color: #1a1a1a;
                                    font-size: 17px;
                                    line-height: 20px;
                                    text-decoration: none;
                                  ""
                                  >1(800)232-90-26</a
                                >
                                &nbsp;&nbsp;|&nbsp;&nbsp;
                                <a
                                  href=""#""
                                  target=""_blank""
                                  style=""
                                    font-family: 'Source Sans Pro', Arial,
                                      Tahoma, Geneva, sans-serif;
                                    color: #1a1a1a;
                                    font-size: 17px;
                                    line-height: 20px;
                                    text-decoration: none;
                                  ""
                                  >Unsubscribe</a
                                ></span
                              >
                            </font>
                            <div
                              style=""
                                height: 35px;
                                line-height: 35px;
                                font-size: 33px;
                              ""
                            >
                              &nbsp;
                            </div>

                            <div
                              style=""
                                height: 35px;
                                line-height: 35px;
                                font-size: 33px;
                              ""
                            >
                              &nbsp;
                            </div>
                          </td>
                        </tr>
                      </table>
                    </td>
                  </tr>
                </table>
              </td>
              <td
                class=""mob_pad""
                width=""25""
                style=""width: 25px; max-width: 25px; min-width: 25px""
              >
                &nbsp;
              </td>
            </tr>
          </table>
          <!--[if (gte mso 9)|(IE)]>
         </td></tr>
         </table><![endif]-->
        </td>
      </tr>
    </table>
  </body>
</html>
";
        }
    }
}
