<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="suppliers.aspx.cs" Inherits="企业信息管理.suppliers" %>

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
  <title>供应商管理 - 企业信息管理系统</title>
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
            <a href="sell.aspx">
              <i class="fa fa-dashboard"></i>
              <span>商品销售</span>
            </a>
          </li>
          <li>
            <a href="supply.aspx">
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
          <li class="active">
            <a href="suppliers.aspx">
              <i class="fa fa-bullhorn"></i>
              <span>供应商管理</span>
            </a>
          </li>
          <li>
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
          <h1><i class="fa fa-dashboard"></i>供应商管理</h1>
        </div>
        <div>
          <ul class="breadcrumb">
            <li><i class="fa fa-home fa-lg"></i></li>
            <li><a href="#">主页</a></li>
          </ul>
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          <div class="card">
            <div class="card-title-w-btn">
              <h3 class="card-title">供应商列表</h3>
              <p><a class="btn btn-primary icon-btn" href=""><i class="fa fa-plus"></i>添加供应商	</a></p>
            </div>
            <form runat="server">
              <asp:GridView
                GridLines="None"
                DataKeyNames="sup_id"
                CssClass="table table-striped"
                runat="server"
                ID="gvCompanyList"
                AutoGenerateColumns="false"
                OnRowCommand="gv_company_list_RowCommand"
                OnRowDeleting="gv_company_list_RowDeleting">
                <FooterStyle BackColor="#c6c3c6" ForeColor="Black" />
                <Columns>
                  <asp:TemplateField HeaderText="供应商ID" Visible="false">
                    <ItemTemplate>
                      <asp:Label runat="server" Text='<%Eval("sup_id") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="序号">
                    <ItemTemplate>
                      <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField DataField="sup_name" HeaderText="供应商" ReadOnly="true" />
                  <asp:ButtonField HeaderText="修改" Text="修改" CommandName="Update"/>
                  <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                      <asp:Button runat="server"
                        ID="delete" CommandName="Delete" CommandArgument="<% Eval('sup_id')%>" Text="删除"
                        OnClientClick="return confirm('你确定删除吗?')" />
                    </ItemTemplate>
                  </asp:TemplateField>
                </Columns>
              </asp:GridView>
              <p class="mt-40 mb-20">
                <a class="btn btn-primary icon-btn mr-10"
                  href="./homework.html">
                  <i class="fa fa-file-text"></i>查看所有作业</a>
                <a class="btn btn-info icon-btn mr-10">
                  <i class="fa fa-github"></i>GitHub</a>
              </p>
            </form>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          <div class="card">
            <h3 class="card-title">修改数据</h3>
            <div class="card-body3">
              <form class="form-inline" runat="server" visible="false">
                <div class="form-group">
                  <label class="control-label">ID</label>
                  <!--input class="form-control" type="text" placeholder="Enter your name"-->
                  <asp:TextBox runat="server" CssClass="form-control" ID="tbID" />
                </div>
                <div class="form-group">
                  <label class="control-label">企业名称</label>
                  <!--input class="form-control" type="text" placeholder="Enter your email"-->
                  <asp:TextBox runat="server" CssClass="form-control" ID="tbCompanyName"></asp:TextBox>
                </div>
                <div class="form-group">
                  <button class="btn btn-primary icon-btn" type="button"><i class="fa fa-fw fa-lg fa-check-circle"></i>Subscribe</button>
                </div>
              </form>
            </div>
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
  <script type="text/javascript" src="js/plugins/jquery.dataTables.min.js"></script>
  <script type="text/javascript" src="js/plugins/dataTables.bootstrap.min.js"></script>
  <script type="text/javascript">$('#<%=gvCompanyList.ClientID%>').DataTable();</script>
</body>
</html>
