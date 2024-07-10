using CruzEvaluacion3P.ViewModels;

namespace CruzEvaluacion3P.View;

public partial class SCFirstPAge : ContentPage
{
	public SCFirstPAge()
	{
		InitializeComponent();
		BindingContext = new SCPeliculaViewModel();
	}
}