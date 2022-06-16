function createModal(selector) {
	if ($(".modal-overlay").length === 0) {
		$("body").prepend('<div tabindex="0" class="cbm-modal-overlay"></div>');
	}

	var modalContent = $(selector);
	modalContent.addClass('cbm-modal');
	modalContent.attr('tabindex', 0);
	modalContent.attr('aria-modal', 'true');

	showModal(selector);
	trapFocusInModal(selector);
}

function trapFocusInModal(selector) {
	var modal = $(selector);

	var focusableElements = modal.find('select, input, textarea, button, a').filter(':visible');

	$('.cbm-modal-overlay').focus(function (e) {
		if (focusableElements.length < 1) setTimeout(function () { modal.focus(); }, 20);
		else setTimeout(function () { focusableElements.first().focus(); }, 20);
	});

	modal.focus();
}

function showModal(selector) {
	$(selector).show();
	$(".cbm-modal-overlay").show();
}

function hideModal(selector) {
	$(selector).hide();
	$(".cbm-modal-overlay").hide();
}