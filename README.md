# gui_study

## Sequence diagrams

### Displaying the votable emojis

```mermaid
sequenceDiagram
    autonumber
    VotingView->>VotingViewModel:Binding
    VotingViewModel->>VotingModel:GetAllEmojis
    VotingModel->>Mediator:Send ListAllEmojis
    Mediator->>ListAllEmojisHandler:Handle ListAllEmojis
    ListAllEmojisHandler->>EmojiService:ListEmojis
    EmojiService->>DatabaseEmojiRepository:List
    DatabaseEmojiRepository-->>EmojiService:IReadOnlyCollection<Emoji>
    EmojiService-->>ListAllEmojisHandler:IEnumerable<Emoji>
    ListAllEmojisHandler-->>Mediator:IEnumerable<EmojiDto>
    Mediator-->>VotingModel:IEnumerable<EmojiDto>
    VotingModel-->>VotingViewModel:IReadOnlyList<EmojiDto>
    VotingViewModel-->>VotingView:Binding
```

### Vote on an emoji

```mermaid
sequenceDiagram
    autonumber
    VotingView->>VotingViewModel:RelayCommand
    VotingViewModel->>VotingModel:Vote
    VotingModel->>Mediator:Send VoteEmojiCommand
    Mediator->> VoteEmojiHandler: Handle VoteEmojiCommand
    VoteEmojiHandler->>VotingService: Vote
    VotingService->>VotingRepository: GetResultByShortcode
    VotingRepository-->>VotingService: VotingResult?
    alt result not exist
        VotingService->>VotingRepository: AddVote
    else result exists
        VotingService->>VotingRepository: UpdateVote
    end
    VotingService-->>Mediator: Publish NewVoteAdded

```

### Handle NewVoteAdded in VotingView

```mermaid
sequenceDiagram
    autonumber
    Mediator-->>VotingViewModel: Handle NewVoteAdded
    VotingViewModel->>VotingModel: FindByShortCode
    VotingModel->>Mediator: Send FindByShortcodeQuery
    Mediator->>FindByShortCodeHandler: Handle FindByShortcodeQuery
    FindByShortCodeHandler->>EmojiService:FindByShortCode
    EmojiService->>DatabaseEmojiRepository:Get
    DatabaseEmojiRepository-->>EmojiService:Emoji?
    EmojiService-->>FindByShortCodeHandler: Emoji?
    FindByShortCodeHandler-->>Mediator: EmojiDto
    Mediator-->>VotingModel: EmojiDto
    VotingModel-->>VotingViewModel: EmojiDto
    VotingViewModel->>Notifier: ShowSuccess
```

### Handle NewVoteAdded in DashboardView

```mermaid
sequenceDiagram
    autonumber
    Mediator-->>DashboardViewModel: Handle NewVoteAdded
    DashboardViewModel->>DashboardModel:GetVotingResults
    DashboardModel->>Mediator:Send ListVotingResultsQuery
    Mediator->>ListVotingResultsHandler:Handle ListVotingResultsQuery
    ListVotingResultsHandler->>VotingService:Results
    VotingService->>VotingRepository:GetResults
    VotingRepository-->>VotingService:IEnumerable<VotingResult>
    VotingService-->>ListVotingResultsHandler:IEnumerable<VotingResult>
    ListVotingResultsHandler-->>Mediator:IEnumerable<VotingResultDto>
    Mediator-->>DashboardModel:IEnumerable<VotingResultDto>
    loop Every VotingResultDto
        DashboardModel->>Mediator:Send FindByShortcodeQuery
        Mediator->>FindByShortCodeHandler:Handle FindByShortcodeQuery
        FindByShortCodeHandler->>EmojiService:FindByShortCode
        EmojiService->>DatabaseEmojiRepository:Get
        DatabaseEmojiRepository-->>EmojiService:Emoji?
        EmojiService-->>FindByShortCodeHandler:Emoji?
        FindByShortCodeHandler-->>Mediator:EmojiDto
        Mediator-->>DashboardModel:EmojiDto
    end
    DashboardModel-->>DashboardViewModel:IEnumerable<Result>
    DashboardViewModel-->DashBoardView: Binding
```

### Displaying the voting results

```mermaid
sequenceDiagram
    autonumber
    DashBoardView->>DashboardViewModel: Binding
    DashboardViewModel->>DashboardModel:GetVotingResults
    DashboardModel->>Mediator:Send ListVotingResultsQuery
    Mediator->>ListVotingResultsHandler:Handle ListVotingResultsQuery
    ListVotingResultsHandler->>VotingService:Results
    VotingService->>VotingRepository:GetResults
    VotingRepository-->>VotingService:IEnumerable<VotingResult>
    VotingService-->>ListVotingResultsHandler:IEnumerable<VotingResult>
    ListVotingResultsHandler-->>Mediator:IEnumerable<VotingResultDto>
    Mediator-->>DashboardModel:IEnumerable<VotingResultDto>
    loop Every VotingResultDto
        DashboardModel->>Mediator:Send FindByShortcodeQuery
        Mediator->>FindByShortCodeHandler:Handle FindByShortcodeQuery
        FindByShortCodeHandler->>EmojiService:FindByShortCode
        EmojiService->>DatabaseEmojiRepository:Get
        DatabaseEmojiRepository-->>EmojiService:Emoji?
        EmojiService-->>FindByShortCodeHandler:Emoji?
        FindByShortCodeHandler-->>Mediator:EmojiDto
        Mediator-->>DashboardModel:EmojiDto
    end
    DashboardModel-->>DashboardViewModel:IEnumerable<Result>
    DashboardViewModel-->DashBoardView: Binding
```
