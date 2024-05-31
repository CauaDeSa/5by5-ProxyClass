package Lib;

import java.util.HashMap;

public interface YouTubeLib {
    HashMap<String, Video> popularVideos();

    Video getVideo(String videoId);
}