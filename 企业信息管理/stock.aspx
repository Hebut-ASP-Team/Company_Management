<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stock.aspx.cs" Inherits="企业信息管理.stock" %>

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
  <title>库存管理 - 企业信息管理系统hyhtest</title>
    <style type="text/css">
        .auto-style1 {
            height: 37px;
        }
    </style>
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
          <li class="active">
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
          <li>
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
            <h1><i class="fa fa-bank"></i> 库存管理</h1>
          </div>
        </div>
        <div class="row">
          <div class="col-md-12">
            <div class="card">
              <div class="card-title-w-btn">
                <h3 class="card-title">商品列表列表</h3>
              </div>

              <asp:GridView
                Font-Size="14px"
                GridLines="None"
                DataKeyNames="goods_id"
                CssClass="table table-striped"
                runat="server"
                ID="gvCompanyList"
                AutoGenerateColumns="false"
                OnRowCommand="gv_company_list_RowCommand"
                OnRowDeleting="gv_company_list_RowDeleting">
                <FooterStyle BackColor="#c6c3c6" ForeColor="Black" />
                <Columns>
                  <asp:BoundField DataField="goods_id" HeaderText="商品ID"></asp:BoundField>
                  <asp:BoundField DataField="goods_name" HeaderText="商品名称" ReadOnly="true" />
                  <asp:BoundField DataField="goods_amount" HeaderText="商品数量" ReadOnly="true" />
                  <asp:ButtonField  HeaderText="修改" Text="修改" CommandName="XX" />
                  <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                      <asp:Button runat="server"
                        ID="delete" CommandName="Delete" CommandArgument="<% Eval('goods_id')%>" Text="删除"
                        OnClientClick="return confirm('你确定删除吗?')" />
                    </ItemTemplate>
                  </asp:TemplateField>
                </Columns>
              </asp:GridView>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-md-12">
            <div class="card">
              <h3 class="card-title">修改数据</h3>
              <div class="card-body3">
                <asp:Panel class="form-inline" runat="server">
                  <div class="form-group">
                    <label class="control-label">ID</label>
                    <asp:TextBox Enabled="false" runat="server" CssClass="form-control" ID="tbID" />
                  </div>
                  <div class="form-group">
                    <label class="control-label">商品名称</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="tbCompanyName"></asp:TextBox>
                  </div>
                  <div class="form-group">
                    <label class="control-label">商品数量</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="tbGoodsAmount"></asp:TextBox>
                  </div>
                  <div class="form-group">
                    <button id="change" class="btn btn-primary icon-btn" type="button"><i class="fa fa-fw fa-lg fa-check-circle"></i>修改</button>
                    <asp:Button runat="server" ID="btnUpdate" OnClick="btnUpdate_Click" Style="display: none" />
                  </div>
                </asp:Panel>
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
<script type="text/javascript" src="js/plugins/jquery.dataTables.min.js"></script>
  <script type="text/javascript" src="js/plugins/dataTables.bootstrap.min.js"></script>
  <script type="text/javascript" src="js/plugins/sweetalert.min.js"></script>
  <script type="text/javascript">
    $('#<%=gvCompanyList.ClientID%>').DataTable({
      language: {
        "sProcessing": "处理中...",
        "sLengthMenu": "显示 _MENU_ 项结果",
        "sZeroRecords": "没有匹配结果",
        "sInfo": "显示第 _START_ 至 _END_ 项结果，共 _TOTAL_ 项",
        "sInfoEmpty": "显示第 0 至 0 项结果，共 0 项",
        "sInfoFiltered": "(由 _MAX_ 项结果过滤)",
        "sInfoPostFix": "",
        "sSearch": "搜索:",
        "sUrl": "",
        "sEmptyTable": "表中数据为空",
        "sLoadingRecords": "载入中...",
        "sInfoThousands": ",",
        "oPaginate": {
          "sFirst": "首页",
          "sPrevious": "上页",
          "sNext": "下页",
          "sLast": "末页"
        },
        "oAria": {
          "sSortAscending": ": 以升序排列此列",
          "sSortDescending": ": 以降序排列此列"
        }
      }
    });</script>
  <script>
    $("#change").click(function () {
      if ($("#<%=tbID.ClientID %>").val().length > 0) {
        document.getElementById("<%=btnUpdate.ClientID %>").click();
      } else {
        swal("请先选择一条数据", "", "error");
      }
    });
  </script>
</body>
</html>
