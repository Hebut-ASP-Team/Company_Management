<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="企业信息管理.login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <meta charset="utf-8" />
  <meta charset="utf-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=edge" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <!-- CSS-->
  <link rel="stylesheet" type="text/css" href="css/main.css" />
  <!-- Font-icon css-->
  <link rel="stylesheet" type="text/css" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
  <title>登录 - 企业信息管理系统</title>
    
    <script src="js/jquery-2.1.4.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</head>
<body>
  <section class="material-half-bg">
    <div class="cover"></div>
  </section>
  <section class="login-content">
    <div class="logo">
      <h1>Red Store</h1>
    </div>
    <div class="login-box">
      <form runat="server" class="login-form">
        <h3 class="login-head"><i class="fa fa-lg fa-fw fa-user"></i>登录</h3>
        <div class="form-group">
          <label class="control-label">用户名</label>
          <asp:TextBox ID="tbUserName" runat="server" CssClass="form-control" AutoCompleteType="Email"  TextMode="Email" />
        </div>
        <div class="form-group">
          <label class="control-label">密码</label>
          <asp:TextBox TextMode="Password" ID="tbPassword" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
          <div class="utility">
            <div class="animated-checkbox">
              <label class="semibold-text">
                <input type="checkbox"/><span class="label-text">保持登录状态</span>
              </label>
            </div>
            <p class="semibold-text mb-0"><a data-toggle="flip">忘记密码</a></p>
          </div>
        </div>
        <div class="form-group btn-container">
          <button id="login"  class="btn btn-primary btn-block" type="button"><i class="fa fa-sign-in fa-lg fa-fw" ></i>登录</button>
          <asp:Button style="display:none;" ID="btnLogin" runat="server" CssClass="btn btn-primary btn-block" />
          <script>document.getElementById("login").addEventListener("click", function () { document.getElementById("<%=btnLogin.ClientID %>").click(); });</script>
        </div>
      </form>
      <form class="forget-form" action="index.html">
        <h3 class="login-head"><i class="fa fa-lg fa-fw fa-lock"></i>忘记密码了?</h3>
        <div class="form-group">
          <label class="control-label">邮箱</label>
          <input class="form-control" type="text" placeholder="Email" />
        </div>
        <div class="form-group btn-container">
          <button class="btn btn-primary btn-block"><i class="fa fa-unlock fa-lg fa-fw"></i>重置</button>
        </div>
        <div class="form-group mt-20">
          <p class="semibold-text mb-0"><a data-toggle="flip"><i class="fa fa-angle-left fa-fw"></i>返回登录</a></p>
        </div>
      </form>
    </div>
  </section>
</body>
<script src="js/plugins/pace.min.js">
<script src="js/main.js"></script>
</html>
