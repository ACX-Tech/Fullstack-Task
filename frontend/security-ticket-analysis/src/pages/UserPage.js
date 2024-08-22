import React from 'react';
import { useParams } from 'react-router-dom';

const UserPage = ({ users }) => {
  const { userId } = useParams();
  const user = users.find(u => u.userId === userId);

  if (!user) return <div>User not found</div>;

  return (
    <div>
      <h1>{user.name}'s Conversations</h1>
      {user.conversations.map(convo => (
        <div key={convo.conversationId}>
          <h3>{convo.title} (Priority: {convo.priority})</h3>
          <p>Status: {convo.status}</p>
          <ActivitySummary messages={convo.messages} />
          <hr />
        </div>
      ))}
    </div>
  );
};

const ActivitySummary = ({ messages }) => {
  const detectedPhrases = messages.filter(msg => msg.userTypeId === 2);

  return (
    <div>
      <h4>Activity Summary</h4>
      {detectedPhrases.length > 0 ? (
        detectedPhrases.map((msg, index) => (
          <div key={index}>
            <button onClick={() => toggleDetails(index)}>
              {msg.content}
            </button>
            <div id={`details-${index}`} style={{ display: 'none' }}>
              <ul>
                {messages.filter(m => m.userTypeId === 1).map((m, i) => (
                  <li key={i}>
                    <strong>{m.timestamp}:</strong> {m.content}
                  </li>
                ))}
              </ul>
            </div>
          </div>
        ))
      ) : (
        <p>No security issues detected.</p>
      )}
    </div>
  );
};

const toggleDetails = (index) => {
  const element = document.getElementById(`details-${index}`);
  element.style.display = element.style.display === 'none' ? 'block' : 'none';
};

export default UserPage;
