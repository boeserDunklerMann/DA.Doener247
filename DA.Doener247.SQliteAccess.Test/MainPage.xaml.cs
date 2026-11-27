using DA.Doener247.Model;

namespace DA.Doener247.SQliteAccess.Test
{
	public partial class MainPage : ContentPage
	{
		private DbContext _ctx;
		public MainPage(DbContext ctx)
		{
			InitializeComponent();
			_ctx = ctx;
		}

		private async void SampleDataBtn_Clicked(object sender, EventArgs e)
		{
			Sosse kraeuter = Sosse.Create<Sosse>();
			Sosse scharf = Sosse.Create<Sosse>();
			Sosse curry = Sosse.Create<Sosse>();
			Sosse knobi = Sosse.Create<Sosse>();
			kraeuter.Bezeichnung = "Kräuter";
			scharf.Bezeichnung = "Scharf";
			curry.Bezeichnung = "Curry";
			knobi.Bezeichnung = "Knobi";

			await _ctx.SaveAsync(kraeuter);
			await _ctx.SaveAsync(scharf);
			await _ctx.SaveAsync(curry);
			await _ctx.SaveAsync(knobi);

			Salat rotkraut = DoenerBase.Create<Salat>();
			rotkraut.Bezeichnung = "Rotkraut";
			Salat Eisberg = DoenerBase.Create<Salat>();
			Eisberg.Bezeichnung = nameof(Eisberg);
			Salat zwiebel = DoenerBase.Create<Salat>();
			zwiebel.Bezeichnung = "Zwibbel";
			Salat Gurke = DoenerBase.Create<Salat>();
			Gurke.Bezeichnung = nameof(Gurke);
			Salat tomate = DoenerBase.Create<Salat>();
			tomate.Bezeichnung = "Tomate";

			await _ctx.SaveAsync(rotkraut);
			await _ctx.SaveAsync(Eisberg);
			await _ctx.SaveAsync(zwiebel);
			await _ctx.SaveAsync(Gurke);
			await _ctx.SaveAsync(tomate);
		}
	}
}
