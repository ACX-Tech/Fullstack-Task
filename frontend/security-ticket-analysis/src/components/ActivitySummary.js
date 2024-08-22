import React from 'react';

const ActivitySummary = ({ detectedWords, conversations }) => (
  <div className="activity-summary">
    <h3>Activity Summary</h3>
    <div className="detected-phrases">
      {detectedWords.map((word, index) => (
        <span key={index} className="detected-word">
          {word}
        </span>
      ))}
    </div>
    <div className="dropdown">
      <button className="dropdown-btn">Show Details</button>
      <div className="dropdown-content">
        {conversations.map((conversation, index) => (
          <div key={index} className="conversation-details">
            <p>{conversation}</p>
          </div>
        ))}
      </div>
    </div>
  </div>
);

export default ActivitySummary;
