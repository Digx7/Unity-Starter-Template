using Unity

public class ConversationHolder : MonoBehavior
{
    public Conversation conversation;
    public Channel onConversationStartChannel;
    public Channel onConversationEndChannel;
    public ConversationChannel onConversationUpdateChannel;

    private int currentNodeIndex = 0;
    private ConversationNode currentNode;
    private bool isConversationGoing = false;

    public void Interact()
    {
        if(!isConversationGoing)
        {
            isConversationGoing = true;
            StartConversation();
        }
        else
        {
            ProgressConversation();
        }
    }

    private void StartConversation()
    {
        currentNodeIndex = 0
        if(TryGetNode())
        {
            onConversationStartChannel.Raise();
            onConversationUpdateChannel.Raise(currentNode);
        }
        else
        {
            EndConversation();
        }
    }

    private void ProgressConversation()
    {
        currentNodeIndex++;
        if(TryGetNode())
        {
            onConversationUpdateChannel.Raise(currentNode);
        }
        else
        {
            EndConversation();
        }
    }

    private void EndConversation()
    {
        isConversationGoing = false;
        onConversationEndChannel.Raise();
        TryLoadNextConversation();
    }

    private bool TryGetNode()
    {
        if(currentNodeIndex < conversation.nodes.length)
        {
            currentNode = conversation.nodes[currentNodeIndex];
            return true;
        }
        return false;
    }

    private bool TryLoadNextConversation()
    {
        if(conversation.nextConversationToLoadOnFinish != null)
        {
            conversation = conversation.nextConversationToLoadOnFinish;
            return true;
        }
        return false;
    }
}