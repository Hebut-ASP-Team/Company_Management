<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="finance.aspx.cs" Inherits="企业信息管理.finance" %>


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
  <title>财务统计 - 企业信息管理系统</title>
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
            <img class="img-circle" src="48.jpg"
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
          <li>
            <a href="staffmanage.aspx">
              <i class="fa fa-address-book"></i>
              <span>员工信息管理</span>
            </a>
          </li>
            <li class="active">
            <a href="finance.aspx">
              <i class="fa fa-cny"></i>
              <span>财务统计</span>
            </a>
          </li>
        </ul>
      </section>
    </aside>
    <div class="content-wrapper">
      <div class="page-title">
        <div>
          <h1><i class="fa fa-cny"></i> 财务统计</h1>
        </div>
        <div>
          <ul class="breadcrumb">
            <li><i class="fa fa-home fa-lg"></i></li>
            <li><a href="index.aspx">主页</a></li>
          </ul>
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          
        </div>
        <div class="col-md-12">
          <div class="card">
            <h3 class="card-title">每月财务统计</h3>
              <div id="main" style="height: 400px"></div>
              
            <a class="btn btn-success icon-btn mr-10" href="./notice.html">
              <i class="fa fa-bullhorn"></i>财务报表</a>
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
  <script src="echarts-2.2.7/build/dist/echarts.js"></script>
    <script type="text/javascript">  

                  require.config({
                      packages : [ {
                          name : 'echarts',
                          location : 'echarts-2.2.7/src',
                          main : 'echarts'
                      }, {
                          name : 'zrender',
                          location : 'echarts-2.2.7/src',
                          main : 'zrender'
                      } ]
                  });
                  require(['echarts', 'echarts/chart/bar', 'echarts/chart/line'],
                  function (ec) {
                      var myChart = ec.init(document.getElementById('main'), 'macarons');
                      var option = {
                          tooltip : {
                              trigger : 'axis'
                          },
                          legend : {
                              data : [ '收入', '支出' ]
                          },
                          toolbox : {
                              show : true,
                              feature : {
                                  mark : true,
                                  dataView : {
                                      readOnly : false
                                  },
                                  magicType : [ 'line', 'bar' ],
                                  restore : true,
                                  saveAsImage : true
                              }
                          },
                          calculable: true,
                          dataZoom: {
                              show: true,
                              realtime: true,
                          },
                          xAxis : [ {
                              type : 'category',
                              data: [ '7月', '8月', '9月', '10月', '11月', '12月', '1月', '2月', '3月', '4月', '5月', '6月']
                          } ],
                          yAxis : [ {
                              type : 'value',
                              splitArea : {
                                  show : true
                              }
                          } ],
                          series : [
                          {
                              name : '收入',
                              type : 'bar',
                              data: [700, 200, 300, 500, 100, 600, 1000, 900, 700.75, 300, 500, 700]
                          },
                          {
                              name : '支出',
                              type : 'bar',
                              data: [400, 300, 100, 300, 200, 300, 700, 500, 400, 200, 300, 100]
                          } ]
                      };   
        // 使用刚指定的配置项和数据显示图表。  
                      myChart.setOption(option);
                      
                  });
    </script>  
</body>
</html>

