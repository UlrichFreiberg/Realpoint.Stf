// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Blog.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the Blog type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Models.Blog
{
    using Realpoint.Stf.RealpointWeb.Interfaces;
    using Realpoint.Stf.RealpointWeb.Interfaces.Blog;

    /// <summary>
    /// The blog.
    /// </summary>
    public class Blog : RealpointWebShellModelBase, IBlog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Blog"/> class.
        /// </summary>
        /// <param name="realpointWebShell">
        /// The realpoint web shell.
        /// </param>
        public Blog(IRealpointWebShell realpointWebShell)
            : base(realpointWebShell)
        {
        }
    }
}