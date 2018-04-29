<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="staffmanage.aspx.cs" Inherits="企业信息管理.staffmanage" %>


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
  <title>员工信息管理 - 企业信息管理系统</title>
</head>
<body class="sidebar-mini fixed">
  <div class="wrapper">
    <!-- Navbar-->
    <header class="main-header hidden-print">
      <a class="logo" href="index.html">Vali</a>
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
                <li class="not-head">You have 4 new notifications.
                </li>
                <li><a class="media" href="javascript:"><span
                  class="media-left media-icon"><span
                    class="fa-stack fa-lg"><i
                      class="fa fa-circle fa-stack-2x text-primary"></i><i
                        class="fa fa-envelope fa-stack-1x fa-inverse"></i></span></span>
                  <div class="media-body">
                    <span class="block">Lisa sent you a mail</span><span
                      class="text-muted block">2min ago</span>
                  </div>
                </a></li>
                <li><a class="media" href="javascript:"><span
                  class="media-left media-icon"><span
                    class="fa-stack fa-lg"><i
                      class="fa fa-circle fa-stack-2x text-danger"></i><i
                        class="fa fa-hdd-o fa-stack-1x fa-inverse"></i></span></span>
                  <div class="media-body">
                    <span class="block">Server Not Working</span><span
                      class="text-muted block">2min ago</span>
                  </div>
                </a></li>
                <li><a class="media" href="javascript:"><span
                  class="media-left media-icon"><span
                    class="fa-stack fa-lg"><i
                      class="fa fa-circle fa-stack-2x text-success"></i><i
                        class="fa fa-money fa-stack-1x fa-inverse"></i></span></span>
                  <div class="media-body">
                    <span class="block">Transaction xyz complete</span><span
                      class="text-muted block">2min ago</span>
                  </div>
                </a></li>
                <li class="not-footer"><a href="#">See all
                                notifications.</a></li>
              </ul>
            </li>
            <!-- User Menu-->
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
                <li><a href="page-login.html"><i
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
              alt="User Image">
          </div>
          <div class="pull-left info">
            <p>用户名</p>
            <p class="designation">属性</p>
          </div>
        </div>
        <!-- 侧边菜单-->
        <ul class="sidebar-menu">
          <li>
            <a href="sell.aspx">
              <i class="fa fa-dashboard"></i>
              <span>商品销售</span>
            </a>
          </li>
          <li>
            <a href="suppliers.aspx">
              <i class="fa fa-file-text"></i>
              <span>商品进货及查询</span>
            </a>
          </li>
          <li>
            <a href="stock.aspx">
              <i class="fa fa-bullhorn"></i>
              <span>库存管理</span>
            </a>
          </li>
          <li>
            <a href="suppliers.aspx">
              <i class="fa fa-bullhorn"></i>
              <span>供应商管理</span>
            </a>
          </li>
          <li class="active">
            <a href="staffmanage.aspx">
              <i class="fa fa-bullhorn"></i>
              <span>员工信息管理</span>
            </a>
          </li>
        </ul>
      </section>
    </aside>
    <div class="content-wrapper">
      <div class="page-title">
        <div>
          <h1><i class="fa fa-dashboard"></i>员工信息管理</h1>
        </div>
        <div>
          <ul class="breadcrumb">
            <li><i class="fa fa-home fa-lg"></i></li>
            <li><a href="#">主页</a></li>
          </ul>
        </div>
      </div>
      <div class="row">
        <div class="col-md-6">
          <div class="card">
            <h3 class="card-title">员工信息列表</h3>
            <form runat="server">
              <asp:GridView
                GridLines="None"
                DataKeyNames="sup_id"
                OnPageIndexChanging="gv_company_list_PageIndexChanging"
                CssClass="table table-striped"
                runat="server"
                ID="gv_company_list"
                AutoGenerateColumns="false" OnRowDeleting="gv_company_list_RowDeleting" OnSelectedIndexChanged="gv_company_list_SelectedIndexChanged">
                <FooterStyle BackColor="#c6c3c6" ForeColor="Black" />
                <Columns>
                  <asp:TemplateField HeaderText="员工ID" Visible="false">
                    <ItemTemplate>
                      <asp:Label runat="server" Text='<%Eval("sts_id") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="序号">
                    <ItemTemplate>
                      <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField DataField="sta_name" HeaderText="姓名" ReadOnly="true" />
                  <asp:BoundField DataField="sta_sex" HeaderText="性别" ReadOnly="true" />
                  <asp:BoundField DataField="sta_age" HeaderText="年龄" ReadOnly="true" />
                  <asp:BoundField DataField="sta_phone" HeaderText="联系方式" ReadOnly="true" />
                  <asp:BoundField DataField="dep_id" HeaderText="部门" ReadOnly="true" />
                  <asp:HyperLinkField
                    DataNavigateUrlFields="sta_name,sta_sex,sta_age,sta_phone,dep_id" DataNavigateUrlFormatString="URL?"
                    DataTextField="sta_name" DataTextFormatString="修改?"
                    HeaderText="修改" />
                  <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                      <asp:Button runat="server"
                        ID="delete" CommandName="Delete" CommandArgument="<% Eval('sta_id')%>" Text="删除"
                        OnClientClick="return confirm('你确定删除吗?')" />
                    </ItemTemplate>
                  </asp:TemplateField>
                </Columns>
              </asp:GridView>
              <p class="mt-40 mb-20">
                <a class="btn btn-primary icon-btn mr-10"
                  href="./homework.html">
                  <i class="fa fa-file-text"></i>添加</a>
                <a class="btn btn-info icon-btn mr-10">
                  <i class="fa fa-github"></i>查询</a>
              </p>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- Javascripts-->
  <script src="js/jquery-2.1.4.min.js"></script>
  <script src="js/bootstrap.min.js"></script>
  <script src="js/plugins/pace.min.js"></script>
  <script src="js/main.js"></script>
</body>
</html>
