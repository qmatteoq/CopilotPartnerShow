using Microsoft.Agents.Builder;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Builder.State;
using Microsoft.Agents.Core.Models;
using TravelAgency.Agents;

namespace TravelAgency.Bots
{
    public class BasicBot: AgentApplication
    {
        private TravelAgent _travelAgent;

        public BasicBot(AgentApplicationOptions options, TravelAgent travelAgent): base(options)
        {
            _travelAgent = travelAgent;

            OnActivity(ActivityTypes.Message, OnMessageAsync);
            OnConversationUpdate(ConversationUpdateEvents.MembersAdded, OnMembersAddedAsync);
        }

        private async Task OnMessageAsync(ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken)
        {
            var response = await _travelAgent.InvokeAgentAsync(turnContext.Activity.Text);
            if (response == null)
            {
                await turnContext.SendActivityAsync(MessageFactory.Text("Sorry, I couldn't get the travel suggestion at the moment."), cancellationToken);
                return;
            }

            var textResponse = MessageFactory.Text(response);

            await turnContext.SendActivityAsync(textResponse, cancellationToken);
        }

        private async Task OnMembersAddedAsync(ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken)
        {
            // When someone (or something) connects to the bot, a MembersAdded activity is received.
            // For this sample,  we treat this as a welcome event, and send a message saying hello.
            // For more details around the membership lifecycle, please see the lifecycle documentation.
            IActivity message = MessageFactory.Text("Hello and Welcome! I'm here to help with all your travel needs!");

            // Send the response message back to the user. 
            await turnContext.SendActivityAsync(message, cancellationToken);
        }
    }
}
