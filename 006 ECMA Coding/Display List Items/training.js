var context="";
var web ="";
var list="";
var item ='';
var lists='';
var collListItem ='';

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
	context.load(this.list);
	
	context.executeQueryAsync(Function.createDelegate(this, this.onSuccess), Function.createDelegate(this, this.onFailure)); 
}

function onSuccess()
{
	var strhtml='<table>';

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

	strhtml+="<tr>";
	strhtml+="<td>List Items</td>";
	strhtml+="<td><b>"+this.list.get_itemCount()+"</b></td>";
	strhtml+="</tr>";

	strhtml+="</table>";

	document.getElementById('trainingdiv').innerHTML=strhtml;
	displayItems();
}

function displayItems()
{
//debugger
context.load(list);
var itemsCount=list.get_itemCount();
//if you are not passing any CAML query then have to use createAllItemsQuery()
var camlQuery = new SP.CamlQuery.createAllItemsQuery();
//var camlQuery = new SP.CamlQuery();
//camlQuery.set_viewXml('<View><Query><Where><Gt><FieldRef Name="Marks" /><Value Type="Number">40</Value></Gt></Where></Query></View>');
collListItem = list.getItems(camlQuery);

context.load(collListItem);
context.executeQueryAsync(Function.createDelegate(this, this.viewItems), Function.createDelegate(this, this.onFailure)); 
}

function viewItems() {
	var listItemInfo = '<table>';
	
	var listItemEnumerator = collListItem.getEnumerator();
	while (listItemEnumerator.moveNext()) {
		var oListItem = listItemEnumerator.get_current();
		
		listItemInfo +="<tr>";
		listItemInfo +="<td>"+oListItem.get_id()+"</td>";
		
		listItemInfo +="<td>"+oListItem.get_item('Title')+"</td>";
		
		listItemInfo +="<td>"+oListItem.get_item('Marks')+"</td>";
		listItemInfo +="</tr>";
	}
	listItemInfo +="</table>";
	document.getElementById('divdisplay').innerHTML=listItemInfo;
}


function onFailure()
{
alert('Fail');
}


function createListItem() {
  //  var clientContext = new SP.ClientContext(siteUrl);
    var oList = context.get_web().get_lists().getByTitle('SCHOOL');
    var itemCreateInfo = new SP.ListItemCreationInformation();
    this.item = oList.addItem(itemCreateInfo);
  
  var strName=document.getElementById("txt1").value;
  var strMarks=document.getElementById("txt2").value;
  //item.set_item('Title', 'My New Item!');
  // item.set_item('Marks', '99');
   
	item.set_item('Title',strName);
	item.set_item('Marks',strMarks);
   
    item.update();
    context.load(item);       
    context.executeQueryAsync(Function.createDelegate(this, this.onQuerySucceeded), Function.createDelegate(this, this.onQueryFailed));
}

function onQuerySucceeded() {
    alert('Item created: ' + item.get_id());
}

function onQueryFailed(sender, args) {
    alert('Request failed. ' + args.get_message() + '\n' + args.get_stackTrace());
}
