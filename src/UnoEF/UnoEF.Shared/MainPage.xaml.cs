using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnoEF.Data;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UnoEF
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static readonly DependencyProperty PostsProperty = DependencyProperty.Register("Posts", typeof(IEnumerable<Post>), typeof(MainPage), new PropertyMetadata(Enumerable.Empty<Post>()));

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            using (var db = new Data.BloggingContext())
            {
                var posts = db.Posts.Include(post => post.Blog).ToList();

                Posts = posts;
            }
        }

        public IEnumerable<Post> Posts
        {
            get { return (IEnumerable<Post>)GetValue(PostsProperty); }
            set { SetValue(PostsProperty, value); }
        }
    }
}
