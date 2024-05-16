using SpotifyWeb;

namespace Odyssey.MusicMatcher;

public class Query
{
    public string Hello()
    {
        return "Hello fatih";
    }

    [GraphQLDescription("Playlists hand-picked to be featured to all users.")]
    public async Task<List<Playlist>> FeaturedPlaylists(SpotifyService spotifyService)
    {
        var response = await spotifyService.GetFeaturedPlaylistsAsync();
        return response.Playlists.Items.Select(item => new Playlist(item)).ToList();
    }

    public async Task<Playlist?> Playlist([ID] string id, SpotifyService spotifyService)
    {
        var response = await spotifyService.GetPlaylistAsync(id);
        var playlist = new Playlist(response);
        return playlist;
    }
}
