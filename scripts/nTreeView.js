var id = new Array();
var values = new Array();

function replaceTreeDiv(newData) {
    getTreeExpandedStatus();
    $('#' + TreeId).html(newData);
    setTreeExpandedStatus();
}

function getTreeExpandedStatus() {
    id = null; id = new Array();
    values = null; values = new Array();

    var arrElems = $('#' + TreeId + ' div[imgID]');

    for (var i = 0; i < arrElems.length; i++) {
        oCurrent = arrElems[i];
        id[i] = oCurrent.id;
        values[i] = oCurrent.style.display;
    }
}
function setTreeExpandedStatus() {
    for (var i = 0; i < id.length; i++) {
        var oCur = $('#' + getEscapedID(id[i]));
        if ($(oCur).attr('imgID') !== undefined) {
            if (values[i] == '') {
                $(oCur).show();
                $('#' + getEscapedID($(oCur).attr('imgID'))).attr('src', minusImg);
            } else {
                $(oCur).hide();
                $('#' + getEscapedID($(oCur).attr('imgID'))).attr('src', plusImg);
            }
        }
    }
}
function getEscapedID(_id) {
    return _id.replace(/\./gi, "\\.").replace(/:/gi, "\\:");
}



function chkUnchk(ele) {

    var _node = getNode(ele);

    var arrElems = _node.getElementsByTagName("input");
    for (var i = 0; i < arrElems.length; i++) {
        var att = arrElems[i].getAttribute('type');
        if (att == "checkbox") {

            arrElems[i].checked = ele.checked;
        }
    }
    checkUncheckParent(_node);
    //  getCheckedValues(TreeId2);
}
function chkUnchkChilds(ele) {
    var _node = ele.parentNode;
    var arrElems = _node.getElementsByTagName("input");
    for (var i = 1; i < arrElems.length; i++) {
        var att = arrElems[i].getAttribute('type');
        if (att == "checkbox") {

            arrElems[i].checked = arrElems[0].checked;
        }
    }

}


function checkUncheckParent(ele) {
    if (isRoot(ele)) return;
    var parent = getParentNode(ele);
    if (isRoot(parent)) return;
    setValue(parent, getValueFromChildNodes(parent));
    checkUncheckParent(parent);
}

function setValue(ele, value) {
    ele.getElementsByTagName("input")[0].checked = value;
}
function getNode(ele) {
    return ele.parentNode;
}
function getParentNode(ele) {
    return ele.parentNode.parentNode;
}
function isRoot(ele) {

    var chk = ele.parentNode;
    if (chk.getAttribute('parent') == "Y") {
        return true;
    } else {
        return false;
    }


}
function getValue(ele) {
    return ele.getElementsByTagName("input")[0].checked;
}
function getValueFromChildNodes(ele) {
    //alert('parent_' + ele.id.substring(1));
    var _parent = document.getElementById('parent_' + ele.id.substring(1));
    // alert('here' + _parent);

    var retVal = true;
    if (_parent != null) {
        var arrElems = _parent.getElementsByTagName("input");
        for (var i = 0; i < arrElems.length; i++) {
            var att = arrElems[i].getAttribute('type');
            // alert(att);
            if (att == "checkbox") {
                if (arrElems[i].checked == false) return false;
            }
        }
    }
    return true;
}



function deSelectAll() {
    var arrElems = document.getElementById(TreeId).getElementsByTagName("a");
    for (var i = 0; i < arrElems.length; i++) {
        var att = arrElems[i].getAttribute('forTree');
        if (att == "y") {
            arrElems[i].className = 'nodeNotSel';
        }
    }
}
function checkExpandStatus(id) {
    return document.getElementById(id).getAttribute('expanded');
}
function setExpandStatus(id, value) {
    document.getElementById(id).setAttribute('expanded', value);
}
function toggle(id) {
    if (checkExpandStatus(id) == "N") {
        View(id.substring(9));
        setExpandStatus(id, "Y")
    }
    var _img = document.getElementById('img_' + id);

    if (document.getElementById(id).style.display == 'none') {
        document.getElementById(id).style.display = '';
        _img.setAttribute('src', minusImg);
    } else {
        document.getElementById(id).style.display = 'none';
        _img.setAttribute('src', plusImg);
    }
}
window.onload = setTreeViewImages;

function onloadFunctionTree() {
    setTreeViewImages();
}

function setTreeViewImages() {

    var arrElems = document.getElementById(TreeId).getElementsByTagName("div");
    for (var i = 0; i < arrElems.length; i++) {
        oCurrent = arrElems[i];
        oAttribute = oCurrent.getAttribute("imgID");

        if (typeof oAttribute == "string" && oAttribute.length > 0) {
            if (oCurrent.style.display == '') {
                if (document.getElementById(oAttribute).getAttribute('src') != minusImg) {
                    document.getElementById(oAttribute).setAttribute('src', minusImg);
                }
            } else {
                document.getElementById(oAttribute).setAttribute('src', plusImg);
            }
        }
    }
}

