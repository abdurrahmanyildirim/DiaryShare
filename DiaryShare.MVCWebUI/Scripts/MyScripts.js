

//$(document).ready(function () {

//    var chat = $.connection.chat;

//    chat.client.addMessage = function (message, targetID, ownID) {
//        if ($("#activeAccountID").val() == ownID) {
//            $("#messagingContent").append("<div class='col-md-7 pull-left alert alert-success' style='height:auto;' >" + message + "</div>");
//            slideDown();
//        } else if ($("#mainAccountID").val() == ownID) {
//            $("#messagingContent").append("<div class='col-md-7 pull-right alert alert-success' style='height:auto;' >" + message + "</div>");
//            slideDown();
//        } else if ($("#mainAccountID").val() == targetID && $("#activeAccountID").val() != ownID) {
//            var quantity = $("#countOfNonReadMessage-" + ownID).val();
//            if (quantity == 0) {
//                $("#count-" + ownID).html(1);
//                $("#countOfNonReadMessage-" + ownID).attr("value", 1);
//            } else {
//                quantity++
//                $("#countOfNonReadMessage-" + ownID).attr("value", quantity);
//                $("#count-" + ownID).html(quantity);
//            }
//        }
//        //if ($("#mainAccountID").val() == targetID) {
//        //    chat.server.update(targetID);
//        //}
//    }

//    //chat.client.updateMessageMaps = function (response, targetID) {
//    //    if ($("#mainAccountID").val() == targetID) {
//    //        $("#messagingMaps").html("");
//    //        $.each(response, function (index, value) {
//    //            var countNonReadMessages = "";
//    //            if (value.CountOfIsNotReadMessage > 0) {
//    //                countNonReadMessages = value.CountOfIsNotReadMessage;
//    //            }
//    //            $("#messagingMaps").append("<tr><td class='messagingAccount'><a class='isClick' data-id='" + value.AccountID + "' href='#' style='text-decoration:none;color:black'>" + value.FirstName + " " + value.LastName + "<span id='count-" + value.AccountID + "' class='badge progress-bar-danger'>" + value.CountOfIsNotReadMessage + "</span><input id='countOfNonReadMessage-" + value.AccountID + "' type='hidden' value=" + countNonReadMessages + " /></a></td></tr>");
//    //        });
//    //    }
//    //}

//    $("#messageSender").click(function () {
//        var ownID = $("#mainAccountID").val();
//        var targetID = $("#activeAccountID").val();
//        if (targetID === "null") {
//            $("#messageWarning").html("Lütfen bir mesajlaşma konusu seçiniz.");
//            $("#messageWarning").show();
//        } else if ($.trim($("#message").val()) == "") {
//            $("#messageWarning").html("Boş mesaj gönderemezsiniz.");
//            $("#messageWarning").show();
//            $("#message").focus();
//        } else {
//            var messageContent = $("#message").val();
//            $("#message").val("");
//            $("#messageWarning").hide();
//            chat.server.sendMessage(messageContent, targetID, ownID);
//        }
//    })

//    $(".isClick").click(function () {
//        $(".messagingAccount").css("background-color", "ButtonFace");
//        $(this).parent().css("background-color", "white");
//        $("#messageWarning").hide();
//        var targetID = this.getAttribute("data-id");
//        $("#activeAccountID").attr("value", targetID);
//        $(this).children(this.firstChild).html("");
//        $("#countOfNonReadMessage-" + targetID).attr("value", 0)
//        chat.server.loadMessages($("#mainAccountID").val(), targetID);
//    })

//    chat.client.loadMessagingContent = function (response, ownID) {
//        if (ownID == $("#mainAccountID").val()) {
//            $("#messagingContent").html("");
//            $.each(response, function (index, value) {
//                $("#messagingContent").append("<div class='" + value.MessagePosition + " alert alert-success' style='height:auto;' >" + value.MessageContent + "</div>");
//            });
//            slideDown();
//        }
//    }

//    $.connection.hub.start();

//})

//function slideDown() {
//    var $chat = $("#messagingContent");
//    $chat.scrollTop($chat.height() * 10000);
//}
