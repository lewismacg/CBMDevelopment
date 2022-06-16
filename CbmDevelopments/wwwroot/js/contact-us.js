var ContactUs = (function () {
	function formPopup(clickable, modal) {
		var modalCreated = false;
		clickable.click(function (e) {
			e.preventDefault();
			if (modalCreated === true) {
				showModal(modal);
			} else {
				createModal(modal, false);
				modalCreated = true;
			}

			$("#btn_cancel").click(function() {
				hideModal(modal);
			});
		});
	}
	return {
		formPopup: formPopup
	}
})();