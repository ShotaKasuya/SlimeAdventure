namespace SceneTransition
{
    public static class StoryState
    {
        public static TalkType ReadTalkType()
        {
            return _currentTalkType;
        }
        private static int _storyStateFlag;
        private static TalkType _currentTalkType;

        public static void TalkEvent(TalkType talkType)
        {
        }
    }

    public enum TalkType
    {
        
    }

    public enum StoryFlag
    {
        
    }
}