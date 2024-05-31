import Downloader.YouTubeDownloader;
import Proxy.YouTubeCacheProxy;
import Lib.YouTubeClass;

public class Demo {

    public static void main(String[] args) {
        YouTubeDownloader downloader = new YouTubeDownloader(new YouTubeClass());
        YouTubeDownloader smartDownloader = new YouTubeDownloader(new YouTubeCacheProxy());

        long naive = test(downloader);
        long smart = test(smartDownloader);

        System.out.print("Time saved by caching proxy: " + (naive - smart) + "ms");
    }

    private static long test(YouTubeDownloader downloader) {
        long startTime = System.currentTimeMillis();

        downloader.renderPopularVideos();

        downloader.renderVideoPage("Cats");
        downloader.renderPopularVideos();
        downloader.renderVideoPage("TikTok Dances");

        downloader.renderVideoPage("Cats");
        downloader.renderVideoPage("Outros");

        long estimatedTime = System.currentTimeMillis() - startTime;
        System.out.print("Time elapsed: " + estimatedTime + "ms\n");
        
        return estimatedTime;
    }
}