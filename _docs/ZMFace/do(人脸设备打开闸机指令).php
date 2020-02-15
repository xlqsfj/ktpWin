<?php include_once("conn.php");?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<?php 
//获取设备的IP
$equipment_ip_sql = "select * from face_equipment_list where device_number = ''";
$equipment_ip_query = mysql_query($equipment_ip_sql);
?>
<script src="js/jquery-3.2.1.min.js"></script>
<script type="text/javascript">
function getrlktip(){
	alert("上来抓取人脸数据");
	var facedburl = "http://192.168.50.195:8080/?action=2";
	$.ajax({
		url:facedburl,
		success:function(result){
    }});
}

function startdoortip(){
	alert("开门");
	var url = "http://192.168.50.195:8080/?action=1";
	$.ajax({
		url:url,
		success:function(result){
    }});
}
</script>
</head>

<body>
<input type="button" onclick="getrlktip()" value="上来抓人脸数据"/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<input type="button" onclick="startdoortip()" value="启动IO口开门"/>
</body>
</html>