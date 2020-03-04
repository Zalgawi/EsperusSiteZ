<div id="upper-content">
	<div class="header-image" style="background-image: url('@ViewData("Background")');"></div>
	<div class="legand-overlay"></div>
	<div class="legand-content container">
		<div class="legand-content-inner">
			<h1 class="legand-header">
				@Html.Encode(ViewData("Legand"))
			</h1>
			@If ViewData("Caption") IsNot Nothing Then
				@:<p class="legand-body">
					@Html.Encode(ViewData("Caption"))
				@:</p>
			End If
			@If ViewData("Contact") IsNot Nothing Then
				@:<h1 class="legand-header">
					@Html.Encode(ViewData("Contact"))
				@:</h1>
			End If
			@If ViewData("Contact_2") IsNot Nothing Then
				@:<h1 class="legand-header">
					@Html.Encode(ViewData("Contact_2"))
				@:</h1>
			End If
		</div>
	</div>
</div>
