package Proxy;

import Lib;
import java.util.HashMap;

public class YouTubeCacheProxy implements YouTubeLib {
    private YouTubeLib youtubeService;
    private HashMap<String, Video> cachePopular = new HashMap<String, Video>();
    private HashMap<String, Video> cacheAll = new HashMap<String, Video>();

    public YouTubeCacheProxy() {
        this.youtubeService = new YouTubeClass();
    }

    @Override
    public HashMap<String, Video> popularVideos() {

        if (cachePopular.isEmpty()) {
            cachePopular = youtubeService.popularVideos();
        } else {
            System.out.println("Lista retornada pela cache.");
        }
        return cachePopular;
    }

    @Override
    public Video getVideo(String videoId) {

        Video video = cacheAll.get(videoId);

        if (video == null) {
            video = youtubeService.getVideo(videoId);
            cacheAll.put(videoId, video);
        } else {
            System.out.println("Video retornado '" + videoId + "' da cache.");
        }
        return video;
    }

    public void reset() {
        cachePopular.clear();
        cacheAll.clear();
    }
}