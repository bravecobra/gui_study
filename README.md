# gui_study

``` mermaid
sequenceDiagram
    DashboardViewModel->>DashboardModel:GetVotingResults
    DashboardModel->>Mediator:ListVotingResultsQuery
    Mediator->>ListVotingResultsHandler:ListVotingResultsQuery
    ListVotingResultsHandler->>VotingService:Results
    VotingService->>VotingRepository:GetResults
    VotingRepository->>VotingService:IEnumerable<VotingResult>
    VotingService->>ListVotingResultsHandler:IEnumerable<VotingResult>
    ListVotingResultsHandler->>Mediator:IEnumerable<VotingResultDto>
    Mediator->>DashboardModel:IEnumerable<VotingResultDto>
    loop Every VotingResultDto
        DashboardModel->>Mediator:FindByShortcodeQuery
        Mediator->>FindByShortCodeHandler:FindByShortcodeQuery
        FindByShortCodeHandler->>EmojiService:FindByShortCode
        EmojiService->>DatabaseEmojiRepository:Get
        DatabaseEmojiRepository->>EmojiService:Emoji?
        EmojiService->>FindByShortCodeHandler:Emoji?
        FindByShortCodeHandler->>Mediator:EmojiDto
        Mediator->>DashboardModel:IEnumerable<EmojiDto>
    end
    DashboardModel->>DashboardViewModel:IEnumerable<Result>

```
