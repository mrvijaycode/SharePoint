
var context="";
var web ="";
var list="";
var item ='';
var lists='';

$(document).ready(function()
 {
	ExecuteOrDelayUntilScriptLoaded(RetrieveListItems, "sp.js");
 });


function RetrieveListItems()
{
	debugger;
	context = new SP.ClientContext.get_current();
	web = context.get_web();
	//context.load(this.web,'Title');
	
	lists = web.get_lists();
	
	list=web.get_lists().getByTitle('SCHOOL');
	this.item = list.getItemById('2');

	context.load(this.item);	
	context.load(this.web);
	context.load(this.lists);
	
	context.executeQueryAsync(Function.createDelegate(this, this.onSuccess), Function.createDelegate(this, this.onFailure)); 
}

function onSuccess()
{
	var strhtml='<table>';
	//var ti= this.web.get_title();
	
	strhtml+="<tr>";
	strhtml+="<td>Title:</td>";
	strhtml+="<td><b>"+this.web.get_title()+"</b></td>";
	strhtml+="</tr>";
	
	strhtml+="<tr>";
	strhtml+="<td>ID:</td>";
	strhtml+="<td><b>"+this.web.get_id()+"</b></td>";
	strhtml+="</tr>";
	
	strhtml+="<tr>";
	strhtml+="<td>Lists Count:</td>";
	strhtml+="<td><b>"+this.lists.get_count()+"</b></td>";
	strhtml+="</tr>";

	
	strhtml+="<tr>";
	strhtml+="<td>Item:</td>";
	strhtml+="<td><b>"+this.item.get_item("Title")+"</b></td>";
	strhtml+="</tr>";
		
	strhtml+="</table>";

	var listcount=this.lists.get_count();

	strhtml+="<table align='center' border='1' style='background-color:yellow;width:100%'>";

	for(i=0;i<listcount;i++)
	{

	strhtml+="<tr>";
	strhtml+="<td style='font-weight:bold'>"+i+"</td>";
	strhtml+="<td>"+lists.get_item(i).get_title()+"</td>";
	strhtml+="</tr>";

	}

	strhtml+="</table>";

	document.getElementById('trainingdiv').innerHTML=strhtml;
	
}

function onFailure()
{
alert('Fail');
}


function main()
{
alert("Welcome to the page");
}