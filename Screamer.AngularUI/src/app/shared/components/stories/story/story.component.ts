import { Component } from '@angular/core';

import { Zuck } from 'zuck.js';

@Component({
  selector: 'app-story',
  templateUrl: './story.component.html',
  styleUrls: ['./story.component.scss'],
})
export class StoryComponent {
  orderedStories: any[] = [];

  ngOnInit() {
    this.loadStories();
    this.initStories();
  }

  loadStories() {
    const stories = [
      {
        escort_id: '1',
        escort: {
          user: {
            name: 'John Doe',
          },
          profile_picture: {
            url: 'avatar1.jpg',
          },
        },
        type: 'PIC',
        upload: {
          url: 'photo1.jpg',
        },
        updated_at: '2023-06-10T10:30:00.000Z',
        text: 'First story',
      },
      {
        escort_id: '2',
        escort: {
          user: {
            name: 'Jane Smith',
          },
          profile_picture: {
            url: 'avatar2.jpg',
          },
        },
        type: 'VIDEO',
        upload: {
          url: 'video1.mp4',
        },
        updated_at: '2023-06-10T11:45:00.000Z',
        text: 'Second story',
      },
    ];

    stories.forEach((story) => {
      const escortId = story.escort_id;
      const escortName = story.escort.user.name;
      const escortAvatar = story.escort.profile_picture
        ? '/' + story.escort.profile_picture.url
        : '/img/defaultAvatar.png';
      const storyType = story.type === 'PIC' ? 'photo' : 'video';
      const storyLength = storyType === 'video' ? 0 : 10;
      const storySrc = '/' + story.upload.url;
      const storyTime = new Date(story.updated_at).getTime() / 1000;
      const storyText = story.text ? story.text : '';

      const newStoryItem = this.buildItem(
        story.escort_id,
        storyType,
        storyLength,
        storySrc,
        storySrc,
        escortId,
        false,
        storyTime,
        storyText
      );

      let alreadyStory = false;
      this.orderedStories.forEach((orderedStory: any) => {
        if (orderedStory.id === escortId) {
          orderedStory.items.push(newStoryItem);
          if (orderedStory.lastUpdated > storyTime) {
            orderedStory.lastUpdated = storyTime;
          }
          alreadyStory = true;
        }
      });

      if (!alreadyStory) {
        const newStory = {
          id: parseInt(escortId),
          photo: escortAvatar,
          link: '/profile/' + escortId,
          lastUpdated: storyTime,
          name: escortName,
          items: [newStoryItem],
        };
        this.orderedStories.push(newStory);
      }
    });
  }

  buildItem(
    id: string,
    type: string,
    length: number,
    src: string,
    preview: string,
    link: string,
    seen: boolean,
    time: number,
    linkText: string
  ) {
    return {
      id: parseInt(id),
      type: type,
      length: length,
      src: src,
      preview: preview,
      link: '/profile/' + link,
      linkText: linkText,
      seen: seen,
      time: time,
    };
  }

  initStories() {
    const stories = Zuck(
      document.querySelector('#stories') as HTMLElement,

      {
        backNative: true,
        autoFullScreen: false,
        skin: 'Snapgram',
        avatars: true,
        list: false,
        cubeEffect: true,
        localStorage: true,
        stories: this.orderedStories,
      }
    );
    document.body.style.display = 'block';
  }
}
