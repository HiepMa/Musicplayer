using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace training.DB.model
{
    class PlaylistSong
    {
        public int Id { get; set; }
        public int PlaylistId { get; set; }
        public int SongId { get; set; }
    }
}
