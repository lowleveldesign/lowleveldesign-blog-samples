<%@ Page Language="C#" %>

<script runat="server">

  public void Page_Load() {
    lblOutput.Text = DateTime.UtcNow.ToString();
  }
</script>

<html>
  <head>
  </head>
  <body>
    <form runat="server">
      <asp:Label Id="lblOutput" runat="server" />
    </form>
  </body>
</html>