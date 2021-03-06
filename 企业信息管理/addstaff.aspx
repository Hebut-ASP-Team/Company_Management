﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addstaff.aspx.cs" Inherits="企业信息管理.addstaff" %>

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
  <link rel="stylesheet" type="text/css"
    href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
  <title>添加供应商 - 企业信息管理系统</title>
</head>
<body class="sidebar-mini fixed">
  <div class="wrapper">
    <!-- Navbar-->
    <header class="main-header hidden-print">
      <a class="logo" href="index.html">Red Store</a>
      <nav class="navbar navbar-static-top">
        <!-- 开启/关闭侧边栏-->
        <a class="sidebar-toggle" href="#"
          data-toggle="offcanvas"></a>
        <!-- 导航栏右侧菜单-->
        <div class="navbar-custom-menu">
          <ul class="top-nav">
            <!--通知菜单-->
            <li class="dropdown notification-menu"><a
              class="dropdown-toggle" href="#"
              data-toggle="dropdown" aria-expanded="false"><i
                class="fa fa-bell-o fa-lg"></i></a>
              <ul class="dropdown-menu">
                <li class="not-head">你有4条通知
                </li>
                <li><a class="media" href="javascript:"><span
                  class="media-left media-icon"><span
                    class="fa-stack fa-lg"><i
                      class="fa fa-circle fa-stack-2x text-primary"></i><i
                        class="fa fa-envelope fa-stack-1x fa-inverse"></i></span></span>
                  <div class="media-body">
                    <span class="block">Lisa给你发了一封邮件</span><span
                      class="text-muted block">2分钟以前</span>
                  </div>
                </a></li>
                <li><a class="media" href="javascript:"><span
                  class="media-left media-icon"><span
                    class="fa-stack fa-lg"><i
                      class="fa fa-circle fa-stack-2x text-danger"></i><i
                        class="fa fa-hdd-o fa-stack-1x fa-inverse"></i></span></span>
                  <div class="media-body">
                    <span class="block">服务器停止工作</span><span
                      class="text-muted block">2分钟以前</span>
                  </div>
                </a></li>
                <li><a class="media" href="javascript:"><span
                  class="media-left media-icon"><span
                    class="fa-stack fa-lg"><i
                      class="fa fa-circle fa-stack-2x text-success"></i><i
                        class="fa fa-money fa-stack-1x fa-inverse"></i></span></span>
                  <div class="media-body">
                    <span class="block">完成事件XYZ</span><span
                      class="text-muted block">2min ago</span>
                  </div>
                </a></li>
                <li class="not-footer"><a href="#">查看所有通知</a></li>
              </ul>
            </li>
            <!-- 用户菜单-->
            <li class="dropdown"><a class="dropdown-toggle" href="#"
              data-toggle="dropdown" role="button"
              aria-haspopup="true"
              aria-expanded="false"><i
                class="fa fa-user fa-lg"></i></a>
              <ul class="dropdown-menu settings-menu">
                <li><a href="page-user.html"><i
                  class="fa fa-cog fa-lg"></i>设置</a>
                </li>
                <li><a href="page-user.html"><i
                  class="fa fa-user fa-lg"></i>个人资料</a>
                </li>
                <li><a href="login.aspx"><i
                  class="fa fa-sign-out fa-lg"></i>注销</a>
                </li>
              </ul>
            </li>
          </ul>
        </div>
      </nav>
    </header>
    <!-- 侧边栏-->
    <aside class="main-sidebar hidden-print">
      <section class="sidebar">
        <div class="user-panel">
          <div class="pull-left image">
            <img class="img-circle" src="https://s3.amazonaws.com/uifaces/faces/twitter/jsa/48.jpg"
              alt="User Image" />
          </div>
          <div class="pull-left info">
            <p>
              <asp:Label runat="server" ID="username" />
            </p>
            <p class="designation">
              <asp:Label runat="server" ID="comment" />
            </p>
          </div>
        </div>
        <!-- 侧边菜单-->
        <ul class="sidebar-menu">
          <li>
            <a href="index.aspx">
              <i class="fa fa-home"></i>
              <span>主页</span>
            </a>
          </li>
          <li>
            <a href="sell.aspx">
              <i class="fa fa-cart-arrow-down"></i>
              <span>商品销售</span>
            </a>
          </li>
          <li>
            <a href="supply.aspx">
              <i class="fa fa-truck"></i>
              <span>商品进货及查询</span>
            </a>
          </li>
          <li>
            <a href="stock.aspx">
              <i class="fa fa-bank"></i>
              <span>库存管理</span>
            </a>
          </li>
          <li>
            <a href="suppliers.aspx">
              <i class="fa fa-vcard-o"></i>
              <span>供应商管理</span>
            </a>
          </li>
          <li class="active">
            <a href="staffmanage.aspx">
              <i class="fa fa-address-book"></i>
              <span>员工信息管理</span>
            </a>
          </li>
          <li>
            <a href="finance.aspx">
              <i class="fa fa-cny"></i>
              <span>财务统计</span>
            </a>
          </li>
        </ul>
      </section>
    </aside>
    <form runat="server">
      <div class="content-wrapper">
        <div class="page-title">
          <div>
            <h1><i class="fa fa-address-book"></i>添加员工信息</h1>
            <ul class="breadcrumb side">
              <li>
                <i class="fa fa-home fa-lg"></i>
              </li>
              <li class="active">
                <a href="suppliers.aspx">员工信息管理</a>
              </li>
              <li>添加员工信息
              </li>
            </ul>
          </div>
        </div>
        <div class="row">
          <div class="col-md-6">
            <div class="card">
              <h3 class="card-title">添加员工信息</h3>
              <div class="card-body">
                <div class="form-group">
                  <label class="control-label">邮箱</label>
                  <asp:TextBox runat="server" AutoCompleteType="Email" TextMode="Email" CssClass="form-control"
                    ID="addstaMAIL"></asp:TextBox>
                </div>
                <div class="form-group">
                  <label class="control-label">姓名</label>
                  <asp:TextBox runat="server" CssClass="form-control" ID="addstaNAME"></asp:TextBox>
                </div>
                <div class="form-group">
                  <label class="control-label">性别</label>
                  <asp:RadioButtonList runat="server" CssClass="form-control" ID="rblMale">
                    <asp:ListItem Value="男" Selected="True">男</asp:ListItem>
                    <asp:ListItem Value="女">女</asp:ListItem>
                  </asp:RadioButtonList>
                </div>
                <div class="form-group">
                  <label class="control-label">年龄</label>
                  <asp:TextBox runat="server" CssClass="form-control" ID="addstaAGE"></asp:TextBox>
                </div>
                <div class="form-group">
                  <label class="control-label">联系方式</label>
                  <asp:TextBox runat="server" CssClass="form-control" ID="addstaPHONE"></asp:TextBox>
                </div>
                <div class="form-group">
                  <label class="control-label">部门</label>
                  <asp:DropDownList CssClass="form-control" runat="server" ID="ddlDepartment"></asp:DropDownList>
                </div>
                <div class="form-group">
                  <label class="control-label">密码</label>
                  <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="addstaPWD"></asp:TextBox>
                </div>
              </div>
              <div class="card-footer">
                <button id="btn_commit" class="btn btn-primary icon-btn" type="button"><i class="fa fa-fw fa-lg fa-check-circle">
                </i>添加</button>
                &nbsp;&nbsp;&nbsp;
                <a class="btn btn-default icon-btn" href="staffmanage.aspx"><i class="fa fa-fw fa-lg fa-times-circle">
                </i>取消</a>
                <asp:Button runat="server" Style="display: none" ID="btnCommit" OnClick="btnCommit_Click" />
                <script>
                  document.getElementById("btn_commit").addEventListener("click", function () {
                    if ($("#<%=addstaNAME.ClientID %>").val().length > 0) {
                      document.getElementById("<%=btnCommit.ClientID %>").click();
                    } else {
                      swal("请输入员工姓名", "", "error");
                    }
                  });
                </script>
              </div>
            </div>
          </div>
        </div>
      </div>
    </form>

  </div>
  <!-- Javascripts-->
  <script src="js/jquery-2.1.4.min.js"></script>
  <script src="js/bootstrap.min.js"></script>
  <script src="js/main.js"></script>
  <script type="text/javascript" src="js/plugins/sweetalert.min.js"></script>
</body>
</html>

