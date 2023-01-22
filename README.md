# gui_study

## Sequence diagrams

### Displaying the votable emojis

``` mermaid
sequenceDiagram

    VotingViewModel->>VotingModel:GetAllEmojis
    VotingModel->>Mediator:ListAllEmojis
    Mediator->>ListAllEmojisHandler:Handle
    ListAllEmojisHandler->>EmojiService:ListEmojis
    EmojiService->>DatabaseEmojiRepository:List
    DatabaseEmojiRepository-->>EmojiService:IReadOnlyCollection<Emoji>
    EmojiService-->>ListAllEmojisHandler:IEnumerable<Emoji>
    ListAllEmojisHandler-->>Mediator:IEnumerable<EmojiDto>
    Mediator-->>VotingModel:IEnumerable<EmojiDto>
    VotingModel-->>VotingViewModel:IReadOnlyList<EmojiDto>
```

### Displaying the voting results

``` mermaid
sequenceDiagram
    DashboardViewModel->>DashboardModel:GetVotingResults
    DashboardModel->>Mediator:ListVotingResultsQuery
    Mediator->>ListVotingResultsHandler:Handle
    ListVotingResultsHandler->>VotingService:Results
    VotingService->>VotingRepository:GetResults
    VotingRepository-->>VotingService:IEnumerable<VotingResult>
    VotingService-->>ListVotingResultsHandler:IEnumerable<VotingResult>
    ListVotingResultsHandler-->>Mediator:IEnumerable<VotingResultDto>
    Mediator-->>DashboardModel:IEnumerable<VotingResultDto>
    loop Every VotingResultDto
        DashboardModel->>Mediator:FindByShortcodeQuery
        Mediator->>FindByShortCodeHandler:Handle
        FindByShortCodeHandler->>EmojiService:FindByShortCode
        EmojiService->>DatabaseEmojiRepository:Get
        DatabaseEmojiRepository-->>EmojiService:Emoji?
        EmojiService-->>FindByShortCodeHandler:Emoji?
        FindByShortCodeHandler-->>Mediator:EmojiDto
        Mediator-->>DashboardModel:EmojiDto
    end
    DashboardModel-->>DashboardViewModel:IEnumerable<Result>
```

